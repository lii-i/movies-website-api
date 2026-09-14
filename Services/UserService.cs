public enum StatusReg {
    Ok = 0,
    ErrorDublicate = 1,
    ErrorData = 2
}

public class UserService{
    private IRepository _rep;

    public UserService(IRepository rep){
        _rep =rep;
    }

    public async Task<StatusReg> RegisterAsync(RegisterData regData){

        try{

            var addr = new System.Net.Mail.MailAddress(regData.Email);
                
            if(regData.Password.Length < 8) return StatusReg.ErrorData;

            await _rep.AddUserAsync(regData);
            return StatusReg.Ok;
        
        }catch(Exception e){
            if( e is ArgumentException) return StatusReg.ErrorDublicate;

            return StatusReg.ErrorDublicate;
        }
    } 

}