
const MOVIES = [
  { id:1, title:"Начало", originalTitle:"Inception", year:2010, genres:["Фантастика","Триллер","Боевик"], rating:8.8, duration:148, ageRating:"13+", country:"США", description:"Кобб — талантливый вор, лучший из лучших в опасном искусстве извлечения секретов из глубин подсознания. Его способности сделали его ценным игроком в шпионском мире, но они же лишили его всего, что он любил. Теперь ему предлагают шанс на искупление: нужно внедрить идею в чужой разум.", poster:"https://picsum.photos/seed/m1/300/450", backdrop:"https://picsum.photos/seed/m1bg/1400/600", director:"Кристофер Нолан", cast:["Леонардо ДиКаприо","Джозеф Гордон-Левитт","Эллиот Пейдж","Том Харди"], related:[2,7,3], featured:true, isNew:false, isPopular:true, gradientFrom:"#1a1a2e", gradientTo:"#4a90e2" },
  { id:2, title:"Интерстеллар", originalTitle:"Interstellar", year:2014, genres:["Фантастика","Драма","Приключения"], rating:8.7, duration:169, ageRating:"12+", country:"США", description:"Когда засуха и вымирание растений угрожают человечеству продовольственным кризисом, группа исследователей отправляется сквозь червоточину за пределы нашей галактики в поисках новой обители для людей.", poster:"https://picsum.photos/seed/m2/300/450", backdrop:"https://picsum.photos/seed/m2bg/1400/600", director:"Кристофер Нолан", cast:["Мэттью Макконахи","Энн Хэтэуэй","Джессика Честейн"], related:[1,4,11], featured:true, isNew:false, isPopular:true, gradientFrom:"#0a0a1a", gradientTo:"#8b4513" },
  { id:3, title:"Тёмный рыцарь", originalTitle:"The Dark Knight", year:2008, genres:["Боевик","Криминал","Драма"], rating:9.0, duration:152, ageRating:"13+", country:"США", description:"Бэтмен поднимает ставки в войне с преступностью. С помощью союзников он намерен уничтожить организованную преступность Готэма, но появляется таинственный злодей — Джокер, сеющий хаос.", poster:"https://picsum.photos/seed/m3/300/450", backdrop:"https://picsum.photos/seed/m3bg/1400/600", director:"Кристофер Нолан", cast:["Кристиан Бэйл","Хит Леджер","Аарон Экхарт","Гэри Олдман"], related:[5,13,14], featured:false, isNew:false, isPopular:true, gradientFrom:"#0d0d0d", gradientTo:"#2c1810" },
  { id:4, title:"Матрица", originalTitle:"The Matrix", year:1999, genres:["Фантастика","Боевик"], rating:8.7, duration:136, ageRating:"16+", country:"США", description:"Программист Томас Андерсон живёт двойной жизнью хакера по имени Нео. Загадочная женщина Тринити приводит его к лидеру подполья Морфеусу, который открывает страшную правду: весь мир — это виртуальная реальность.", poster:"https://picsum.photos/seed/m4/300/450", backdrop:"https://picsum.photos/seed/m4bg/1400/600", director:"Вачовски", cast:["Киану Ривз","Лоренс Фишберн","Кэрри-Энн Мосс"], related:[1,2,6], featured:false, isNew:false, isPopular:true, gradientFrom:"#001a00", gradientTo:"#003300" },
  { id:5, title:"Бойцовский клуб", originalTitle:"Fight Club", year:1999, genres:["Драма","Триллер"], rating:8.8, duration:139, ageRating:"18+", country:"США", description:"Неудовлетворённый своей жизнью клерк знакомится с харизматичным торговцем мылом Тайлером Дёрденом. Вместе они создают подпольный бойцовский клуб, превращающийся в нечто куда более опасное.", poster:"https://picsum.photos/seed/m5/300/450", backdrop:"https://picsum.photos/seed/m5bg/1400/600", director:"Дэвид Финчер", cast:["Брэд Питт","Эдвард Нортон","Хелена Бонем Картер"], related:[3,14,19], featured:false, isNew:false, isPopular:true, gradientFrom:"#1a0000", gradientTo:"#3d1515" },
  { id:6, title:"Форрест Гамп", originalTitle:"Forrest Gump", year:1994, genres:["Драма","Мелодрама"], rating:8.8, duration:142, ageRating:"12+", country:"США", description:"История необычного человека с невысоким IQ, но большим сердцем. Случайно оказываясь в центре важнейших событий американской истории, он остаётся верен себе и своей любви.", poster:"https://picsum.photos/seed/m6/300/450", backdrop:"https://picsum.photos/seed/m6bg/1400/600", director:"Роберт Земекис", cast:["Том Хэнкс","Робин Райт","Гэри Синиз"], related:[15,8,16], featured:false, isNew:false, isPopular:true, gradientFrom:"#1a1a0a", gradientTo:"#3d6b1a" },
  { id:7, title:"Отступники", originalTitle:"The Departed", year:2006, genres:["Криминал","Триллер","Драма"], rating:8.5, duration:151, ageRating:"18+", country:"США", description:"В бостонской полиции внедрён агент мафии, а в мафии — полицейский осведомитель. Оба знают, что другой существует, и начинается опасная игра на выживание.", poster:"https://picsum.photos/seed/m7/300/450", backdrop:"https://picsum.photos/seed/m7bg/1400/600", director:"Мартин Скорсезе", cast:["Леонардо ДиКаприо","Мэтт Дэймон","Джек Николсон"], related:[5,3,14], featured:false, isNew:false, isPopular:true, gradientFrom:"#0a0a0a", gradientTo:"#1a1a3d" },
  { id:8, title:"Властелин колец: Братство кольца", originalTitle:"The Lord of the Rings: The Fellowship of the Ring", year:2001, genres:["Фэнтези","Приключения","Драма"], rating:8.8, duration:228, ageRating:"12+", country:"Новая Зеландия", description:"Молодой хоббит Фродо получает опасное наследство — Кольцо Всевластья. Вместе с отрядом верных друзей он отправляется в опасное путешествие, чтобы уничтожить артефакт в жерле вулкана.", poster:"https://picsum.photos/seed/m8/300/450", backdrop:"https://picsum.photos/seed/m8bg/1400/600", director:"Питер Джексон", cast:["Элайджа Вуд","Иэн МакКеллен","Вигго Мортенсен"], related:[9,10,12], featured:false, isNew:false, isPopular:true, gradientFrom:"#0a1a0a", gradientTo:"#2d4a1a" },
  { id:9, title:"Властелин колец: Две крепости", originalTitle:"The Lord of the Rings: The Two Towers", year:2002, genres:["Фэнтези","Приключения","Драма"], rating:8.7, duration:235, ageRating:"12+", country:"Новая Зеландия", description:"Братство распалось. Фродо и Сэм продолжают путь к Мордору под руководством Горлума. Арагорн, Леголас и Гимли отправляются на поиски похищенных хоббитов.", poster:"https://picsum.photos/seed/m9/300/450", backdrop:"https://picsum.photos/seed/m9bg/1400/600", director:"Питер Джексон", cast:["Элайджа Вуд","Иэн МакКеллен","Вигго Мортенсен"], related:[8,10,12], featured:false, isNew:false, isPopular:true, gradientFrom:"#0f1a0a", gradientTo:"#3d4a00" },
  { id:10, title:"Властелин колец: Возвращение короля", originalTitle:"The Lord of the Rings: The Return of the King", year:2003, genres:["Фэнтези","Приключения","Драма"], rating:8.9, duration:251, ageRating:"12+", country:"Новая Зеландия", description:"Финальная битва Средиземья. Фродо приближается к Роковой горе, а Арагорн ведёт армию людей в сражение, которое решит судьбу всего мира.", poster:"https://picsum.photos/seed/m10/300/450", backdrop:"https://picsum.photos/seed/m10bg/1400/600", director:"Питер Джексон", cast:["Элайджа Вуд","Иэн МакКеллен","Вигго Мортенсен"], related:[8,9,12], featured:false, isNew:false, isPopular:true, gradientFrom:"#1a0a0a", gradientTo:"#4a2000" },
  { id:11, title:"Дюна", originalTitle:"Dune", year:2021, genres:["Фантастика","Приключения","Драма"], rating:8.0, duration:155, ageRating:"12+", country:"США", description:"Пол Атрейдес — блестящий и одарённый юноша, рождённый для великой судьбы. Он должен отправиться на опаснейшую планету во вселенной, чтобы обеспечить будущее своей семьи и народа.", poster:"https://picsum.photos/seed/m11/300/450", backdrop:"https://picsum.photos/seed/m11bg/1400/600", director:"Дени Вильнёв", cast:["Тимоти Шаламе","Зендея","Ребекка Фергюсон"], related:[2,12,1], featured:true, isNew:false, isPopular:true, gradientFrom:"#1a1200", gradientTo:"#4a3000" },
  { id:12, title:"Аватар", originalTitle:"Avatar", year:2009, genres:["Фантастика","Приключения","Боевик"], rating:7.9, duration:162, ageRating:"12+", country:"США", description:"На луне Пандора, богатой редким минералом, паралитик Джейк Салли управляет искусственным телом местного жителя — на'ви. Он оказывается разорван между двумя мирами.", poster:"https://picsum.photos/seed/m12/300/450", backdrop:"https://picsum.photos/seed/m12bg/1400/600", director:"Джеймс Кэмерон", cast:["Сэм Уортингтон","Зои Салдана","Сигурни Уивер"], related:[11,2,13], featured:false, isNew:false, isPopular:true, gradientFrom:"#001a1a", gradientTo:"#004d40" },
  { id:13, title:"Мстители: Финал", originalTitle:"Avengers: Endgame", year:2019, genres:["Боевик","Фантастика","Приключения"], rating:8.4, duration:181, ageRating:"12+", country:"США", description:"После разрушительных событий Мститель остаётся лишь горстка. Они должны собраться вновь, чтобы отменить действия Таноса и восстановить порядок во вселенной.", poster:"https://picsum.photos/seed/m13/300/450", backdrop:"https://picsum.photos/seed/m13bg/1400/600", director:"Братья Руссо", cast:["Роберт Дауни мл.","Крис Эванс","Марк Руффало","Крис Хемсворт"], related:[3,5,7], featured:false, isNew:false, isPopular:true, gradientFrom:"#0a0a1a", gradientTo:"#1a003d" },
  { id:14, title:"Джокер", originalTitle:"Joker", year:2019, genres:["Триллер","Драма","Криминал"], rating:8.4, duration:122, ageRating:"18+", country:"США", description:"Артур Флек — неудачливый стендап-комик, которого отвергает общество. Постепенно его опускающийся в безумие разум превращает его в символ хаоса — Джокера.", poster:"https://picsum.photos/seed/m14/300/450", backdrop:"https://picsum.photos/seed/m14bg/1400/600", director:"Тодд Филлипс", cast:["Хоакин Феникс","Роберт Де Ниро","Зази Битц"], related:[3,5,7], featured:true, isNew:false, isPopular:true, gradientFrom:"#1a0500", gradientTo:"#5c1a00" },
  { id:15, title:"1+1", originalTitle:"The Intouchables", year:2011, genres:["Драма","Комедия","Мелодрама"], rating:8.8, duration:112, ageRating:"16+", country:"Франция", description:"Богатый аристократ Филипп после несчастного случая прикован к инвалидному креслу. Он нанимает сиделкой молодого безработного парня из трущоб — и их невероятная дружба меняет обоих.", poster:"https://picsum.photos/seed/m15/300/450", backdrop:"https://picsum.photos/seed/m15bg/1400/600", director:"Оливье Накаш", cast:["Франсуа Клюзе","Омар Си"], related:[6,16,18], featured:false, isNew:false, isPopular:true, gradientFrom:"#0a1a0a", gradientTo:"#1a3d2d" },
  { id:16, title:"Зелёная книга", originalTitle:"Green Book", year:2018, genres:["Драма","Биография","Комедия"], rating:8.2, duration:130, ageRating:"12+", country:"США", description:"1962 год. Итальянский американец Тони работает водителем у чернокожего пианиста Дона Шёрли в турне по сегрегированному Югу. Несмотря на различия, они находят взаимопонимание.", poster:"https://picsum.photos/seed/m16/300/450", backdrop:"https://picsum.photos/seed/m16bg/1400/600", director:"Питер Фаррелли", cast:["Вигго Мортенсен","Махершала Али"], related:[15,6,18], featured:false, isNew:false, isPopular:false, gradientFrom:"#1a1000", gradientTo:"#3d2800" },
  { id:17, title:"Паразиты", originalTitle:"Parasite", year:2019, genres:["Триллер","Драма","Криминал"], rating:8.5, duration:132, ageRating:"18+", country:"Южная Корея", description:"Малообеспеченная семья постепенно проникает в жизнь состоятельного семейства, обманом завоёвывая их доверие. Но тайны, которые хранит богатый дом, меняют всё.", poster:"https://picsum.photos/seed/m17/300/450", backdrop:"https://picsum.photos/seed/m17bg/1400/600", director:"Пон Чжун Хо", cast:["Со Кан Чжун","Чан Хе Джин","Чхве Вон Сик"], related:[5,7,14], featured:false, isNew:false, isPopular:true, gradientFrom:"#0a1a00", gradientTo:"#1a3300" },
  { id:18, title:"Унесённые призраками", originalTitle:"Spirited Away", year:2001, genres:["Аниме","Фэнтези","Приключения"], rating:8.6, duration:125, ageRating:"6+", country:"Япония", description:"10-летняя Тихиро вместе с родителями попадает в волшебный мир духов. Чтобы спасти заколдованных родителей и вернуться домой, ей придётся работать в таинственных банях.", poster:"https://picsum.photos/seed/m18/300/450", backdrop:"https://picsum.photos/seed/m18bg/1400/600", director:"Хаяо Миядзаки", cast:["Руми Хиираги","Ми Ири"], related:[15,16,20], featured:false, isNew:false, isPopular:true, gradientFrom:"#001a1a", gradientTo:"#1a3d5c" },
  { id:19, title:"Криминальное чтиво", originalTitle:"Pulp Fiction", year:1994, genres:["Криминал","Триллер","Драма"], rating:8.9, duration:154, ageRating:"18+", country:"США", description:"Несколько историй криминального Лос-Анджелеса переплетаются в нелинейном повествовании. Два наёмника, боксёр, гангстер и его жена — судьбы пересекаются непредсказуемо.", poster:"https://picsum.photos/seed/m19/300/450", backdrop:"https://picsum.photos/seed/m19bg/1400/600", director:"Квентин Тарантино", cast:["Джон Траволта","Сэмюэл Л. Джексон","Ума Турман","Брюс Уиллис"], related:[5,7,17], featured:false, isNew:false, isPopular:true, gradientFrom:"#1a0a00", gradientTo:"#4a1a00" },
  { id:20, title:"Побег из Шоушенка", originalTitle:"The Shawshank Redemption", year:1994, genres:["Драма","Криминал"], rating:9.3, duration:142, ageRating:"16+", country:"США", description:"Банкир Энди Дюфресн приговорён к пожизненному заключению за убийство жены и её любовника. В тюрьме Шоушенк он встречает Рэда — и их дружба становится историей о надежде.", poster:"https://picsum.photos/seed/m20/300/450", backdrop:"https://picsum.photos/seed/m20bg/1400/600", director:"Фрэнк Дарабонт", cast:["Тим Роббинс","Морган Фриман"], related:[6,15,16], featured:false, isNew:false, isPopular:true, gradientFrom:"#0a0a00", gradientTo:"#2d2d00" },
  { id:21, title:"Гравитация", originalTitle:"Gravity", year:2013, genres:["Фантастика","Триллер","Драма"], rating:7.7, duration:91, ageRating:"12+", country:"США", description:"Медицинский инженер и опытный астронавт оказываются в открытом космосе после разрушения шаттла. Им нужно найти способ вернуться на Землю.", poster:"https://picsum.photos/seed/m21/300/450", backdrop:"https://picsum.photos/seed/m21bg/1400/600", director:"Альфонсо Куарон", cast:["Сандра Буллок","Джордж Клуни"], related:[2,11,1], featured:false, isNew:true, isPopular:false, gradientFrom:"#000a1a", gradientTo:"#001a3d" },
  { id:22, title:"Достать ножи", originalTitle:"Knives Out", year:2019, genres:["Детектив","Криминал","Комедия"], rating:7.9, duration:130, ageRating:"16+", country:"США", description:"После таинственной гибели главы знаменитой семьи детективов Бланко берётся за расследование. Сложный ребус с множеством подозреваемых раскрывает семейные тайны.", poster:"https://picsum.photos/seed/m22/300/450", backdrop:"https://picsum.photos/seed/m22bg/1400/600", director:"Райан Джонсон", cast:["Дэниел Крейг","Ана де Армас","Крис Эванс"], related:[17,7,5], featured:false, isNew:true, isPopular:false, gradientFrom:"#0a0a1a", gradientTo:"#2d1a3d" },
  { id:23, title:"Дюна: Часть вторая", originalTitle:"Dune: Part Two", year:2024, genres:["Фантастика","Приключения","Драма"], rating:8.5, duration:166, ageRating:"12+", country:"США", description:"Пол Атрейдес объединяется с Чани и фрименами, вступая на путь мести против тех, кто уничтожил его семью. Он сталкивается с выбором между любовью и судьбой вселенной.", poster:"https://picsum.photos/seed/m23/300/450", backdrop:"https://picsum.photos/seed/m23bg/1400/600", director:"Дени Вильнёв", cast:["Тимоти Шаламе","Зендея","Остин Батлер","Флоренс Пью"], related:[11,2,1], featured:true, isNew:true, isPopular:true, gradientFrom:"#1a0f00", gradientTo:"#5c3d00" },
  { id:24, title:"Оппенгеймер", originalTitle:"Oppenheimer", year:2023, genres:["Биография","Драма","История"], rating:8.3, duration:180, ageRating:"16+", country:"США", description:"История создателя атомной бомбы — гениального физика Роберта Оппенгеймера. Триумф науки обернулся нравственной трагедией человека, изменившего мир навсегда.", poster:"https://picsum.photos/seed/m24/300/450", backdrop:"https://picsum.photos/seed/m24bg/1400/600", director:"Кристофер Нолан", cast:["Киллиан Мёрфи","Эмили Блант","Мэтт Дэймон","Роберт Дауни мл."], related:[7,5,14], featured:true, isNew:true, isPopular:true, gradientFrom:"#1a0500", gradientTo:"#3d1000" }
];

const GENRES = ["Боевик","Триллер","Драма","Фантастика","Криминал","Комедия","Приключения","Мелодрама","Биография","Фэнтези","Аниме","Детектив","История","Ужасы"];
const AGE_RATINGS = ["0+","6+","12+","13+","16+","18+"];

function getMovieById(id) {
  return MOVIES.find(m => m.id === parseInt(id));
}

function searchMovies(query, filters = {}) {
  let results = [...MOVIES];
  if (query) {
    const q = query.toLowerCase();
    results = results.filter(m =>
      m.title.toLowerCase().includes(q) ||
      m.originalTitle.toLowerCase().includes(q) ||
      m.director.toLowerCase().includes(q)
    );
  }
  if (filters.genre) results = results.filter(m => m.genres.includes(filters.genre));
  if (filters.ageRating) results = results.filter(m => m.ageRating === filters.ageRating);
  if (filters.yearFrom) results = results.filter(m => m.year >= parseInt(filters.yearFrom));
  if (filters.yearTo) results = results.filter(m => m.year <= parseInt(filters.yearTo));
  if (filters.minRating) results = results.filter(m => m.rating >= parseFloat(filters.minRating));
  if (filters.sortBy === 'rating') results.sort((a,b) => b.rating - a.rating);
  else if (filters.sortBy === 'year') results.sort((a,b) => b.year - a.year);
  else if (filters.sortBy === 'title') results.sort((a,b) => a.title.localeCompare(b.title));
  return results;
}

function formatDuration(min) {
  const h = Math.floor(min / 60), m = min % 60;
  return `${h}ч ${m}м`;
}

function getStars(rating) {
  const full = Math.floor(rating / 2), half = rating % 2 >= 1 ? 1 : 0;
  return '★'.repeat(full) + (half ? '½' : '') + '☆'.repeat(5 - full - half);
}

function getRatingClass(r) {
  if (r >= 8) return 'rating-high';
  if (r >= 6) return 'rating-mid';
  return 'rating-low';
}

function getRelatedMovies(movie) {
  return movie.related.map(id => getMovieById(id)).filter(Boolean);
}

function isInWatchlist(id) {
  const list = JSON.parse(localStorage.getItem('watchlist') || '[]');
  return list.includes(id);
}

function toggleWatchlist(id) {
  let list = JSON.parse(localStorage.getItem('watchlist') || '[]');
  if (list.includes(id)) list = list.filter(x => x !== id);
  else list.push(id);
  localStorage.setItem('watchlist', JSON.stringify(list));
  return list.includes(id);
}

function getWatchlist() {
  const ids = JSON.parse(localStorage.getItem('watchlist') || '[]');
  return ids.map(id => getMovieById(id)).filter(Boolean);
}

function getCurrentUser() {
  return JSON.parse(localStorage.getItem('currentUser') || 'null');
}

function logout() {
  localStorage.removeItem('currentUser');
  window.location.href = '/auth.html';
}
