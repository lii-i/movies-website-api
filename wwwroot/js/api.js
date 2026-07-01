/**
 * CineVault API Client
 * Пытается получить данные с API, при ошибке — возвращает mock-данные из data.js
 * 
 * === ВСЕ URL ПУТИ ДЛЯ РЕАЛИЗАЦИИ НА БЭКЕ ===
 *
 * ФИЛЬМЫ:
 *   GET  /api/movies                          — все фильмы (фильтрация через query params)
 *   GET  /api/movies/featured                 — фильмы для hero-баннера
 *   GET  /api/movies/popular                  — популярные фильмы
 *   GET  /api/movies/new                      — новинки
 *   GET  /api/movies/:id                      — один фильм по id
 *   GET  /api/movies/:id/related              — похожие фильмы
 *
 * ПОИСК:
 *   GET  /api/search?q=&genre=&ageRating=&yearFrom=&yearTo=&minRating=&sortBy=&page=&pageSize=
 *
 * ЖАНРЫ:
 *   GET  /api/genres                          — список всех жанров
 *
 * АВТОРИЗАЦИЯ:
 *   POST /api/auth/login                      — { email, password }
 *   POST /api/auth/register                   — { name, email, password }
 *   POST /api/auth/logout                     — выход
 *
 * ПОЛЬЗОВАТЕЛЬ (требует заголовок Authorization: Bearer <token>):
 *   GET    /api/users/me                      — профиль текущего пользователя
 *   PUT    /api/users/me                      — обновить профиль { name, email }
 *   GET    /api/users/me/watchlist            — список просмотра
 *   POST   /api/users/me/watchlist/:movieId   — добавить в список
 *   DELETE /api/users/me/watchlist/:movieId   — удалить из списка
 */

const API_BASE = '/api';

// Получить токен из localStorage
function getToken() {
    const user = JSON.parse(localStorage.getItem('currentUser') || 'null');
    return user?.token || null;
}

// Базовый fetch с авторизацией
async function apiFetch(url, options = {}) {
    const token = getToken();
    const headers = { 'Content-Type': 'application/json', ...options.headers };
    if (token) headers['Authorization'] = `Bearer ${token}`;

    const res = await fetch(API_BASE + url, { ...options, headers });

    if (!res.ok) {
        const err = await res.json().catch(() => ({ message: res.statusText }));
        throw new Error(err.message || `HTTP ${res.status}`);
    }
    return res.json();
}

// ─── ФИЛЬМЫ ───────────────────────────────────────────────────

async function apiGetMovies(filters = {}) {
    try {
        const params = new URLSearchParams();
        if (filters.genre)     params.set('genre', filters.genre);
        if (filters.ageRating) params.set('ageRating', filters.ageRating);
        if (filters.yearFrom)  params.set('yearFrom', filters.yearFrom);
        if (filters.yearTo)    params.set('yearTo', filters.yearTo);
        if (filters.minRating) params.set('minRating', filters.minRating);
        if (filters.sortBy)    params.set('sortBy', filters.sortBy);
        if (filters.lastId)    params.set('lastId', filters.lastId);   // cursor: ID последнего фильма на странице
        if (filters.pageSize)  params.set('pageSize', filters.pageSize || 20);
        return await apiFetch(`/movies?${params}`);
    } catch (e) {
        console.warn('[API] /movies — используются mock-данные:', e.message);
        return searchMovies('', filters);
    }
}

async function apiGetFeatured() {
    try {
        return await apiFetch('/movies/featured');
    } catch (e) {
        console.warn('[API] /movies/featured — используются mock-данные:', e.message);
        return MOVIES.filter(m => m.featured);
    }
}

async function apiGetPopular() {
    try {
        return await apiFetch('/movies/popular');
    } catch (e) {
        console.warn('[API] /movies/popular — используются mock-данные:', e.message);
        return MOVIES.filter(m => m.isPopular);
    }
}

async function apiGetNew() {
    try {
        return await apiFetch('/movies/new');
    } catch (e) {
        console.warn('[API] /movies/new — используются mock-данные:', e.message);
        return MOVIES.filter(m => m.isNew);
    }
}

async function apiGetMovie(id) {
    try {
        return await apiFetch(`/movies/${id}`);
    } catch (e) {
        console.warn(`[API] /movies/${id} — используются mock-данные:`, e.message);
        return getMovieById(id);
    }
}

async function apiGetRelated(id) {
    try {
        return await apiFetch(`/movies/${id}/related`);
    } catch (e) {
        console.warn(`[API] /movies/${id}/related — используются mock-данные:`, e.message);
        const movie = getMovieById(id);
        return movie ? getRelatedMovies(movie) : [];
    }
}

// ─── ПОИСК ────────────────────────────────────────────────────

async function apiSearch(query, filters = {}) {
    try {
        const params = new URLSearchParams({ q: query || '' });
        Object.entries(filters).forEach(([k, v]) => v && params.set(k, v));
        return await apiFetch(`/search?${params}`);
    } catch (e) {
        console.warn('[API] /search — используются mock-данные:', e.message);
        return searchMovies(query, filters);
    }
}

// ─── ЖАНРЫ ────────────────────────────────────────────────────

async function apiGetGenres() {
    try {
        return await apiFetch('/genres');
    } catch (e) {
        console.warn('[API] /genres — используются mock-данные:', e.message);
        return GENRES.map(name => ({
            name,
            count: MOVIES.filter(m => m.genres.includes(name)).length
        }));
    }
}

// ─── АВТОРИЗАЦИЯ ──────────────────────────────────────────────

async function apiLogin(email, password) {
    try {
        const data = await apiFetch('/auth/login', {
            method: 'POST',
            body: JSON.stringify({ email, password })
        });
        // data должен вернуть { user: {...}, token: "..." }
        localStorage.setItem('currentUser', JSON.stringify(data.user || data));
        return data;
    } catch (e) {
        // Fallback: проверить localStorage
        const users = JSON.parse(localStorage.getItem('users') || '[]');
        const user = users.find(u => u.email === email && u.password === password);
        if (!user) throw new Error('Неверный email или пароль');
        localStorage.setItem('currentUser', JSON.stringify(user));
        return { user };
    }
}

async function apiRegister(name, email, password) {
    try {
        const data = await apiFetch('/auth/register', {
            method: 'POST',
            body: JSON.stringify({ name, email, password })
        });
        localStorage.setItem('currentUser', JSON.stringify(data.user || data));
        return data;
    } catch (e) {
        // Fallback: сохранить в localStorage
        const users = JSON.parse(localStorage.getItem('users') || '[]');
        if (users.find(u => u.email === email)) throw new Error('Email уже зарегистрирован');
        const user = { id: Date.now(), name, email, password, createdAt: new Date().toISOString() };
        users.push(user);
        localStorage.setItem('users', JSON.stringify(users));
        localStorage.setItem('currentUser', JSON.stringify(user));
        return { user };
    }
}

async function apiLogout() {
    try {
        await apiFetch('/auth/logout', { method: 'POST' });
    } catch (_) {}
    localStorage.removeItem('currentUser');
    window.location.href = '/auth.html';
}

// ─── СПИСОК ПРОСМОТРА ─────────────────────────────────────────

async function apiGetWatchlist() {
    try {
        return await apiFetch('/users/me/watchlist');
    } catch (e) {
        console.warn('[API] /users/me/watchlist — используется localStorage:', e.message);
        return getWatchlist();
    }
}

async function apiAddToWatchlist(movieId) {
    try {
        return await apiFetch(`/users/me/watchlist/${movieId}`, { method: 'POST' });
    } catch (e) {
        console.warn('[API] POST watchlist — используется localStorage:', e.message);
        toggleWatchlist(movieId);
        return { success: true };
    }
}

async function apiRemoveFromWatchlist(movieId) {
    try {
        return await apiFetch(`/users/me/watchlist/${movieId}`, { method: 'DELETE' });
    } catch (e) {
        console.warn('[API] DELETE watchlist — используется localStorage:', e.message);
        toggleWatchlist(movieId);
        return { success: true };
    }
}

// ─── ПРОФИЛЬ ─────────────────────────────────────────────────

async function apiGetProfile() {
    try {
        return await apiFetch('/users/me');
    } catch (e) {
        console.warn('[API] /users/me — используется localStorage:', e.message);
        return getCurrentUser();
    }
}

async function apiUpdateProfile(data) {
    try {
        const updated = await apiFetch('/users/me', {
            method: 'PUT',
            body: JSON.stringify(data)
        });
        localStorage.setItem('currentUser', JSON.stringify(updated));
        return updated;
    } catch (e) {
        const user = { ...getCurrentUser(), ...data };
        localStorage.setItem('currentUser', JSON.stringify(user));
        return user;
    }
}
