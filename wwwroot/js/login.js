var url = new URL(window.location.href);
if(url.searchParams.get("name")){
    var username = url.searchParams.get("name");
    var users=[];
    if (!sessionStorage.getItem('user')){
        sessionStorage.setItem('user', JSON.stringify(users));
    }
    users= JSON.parse(sessionStorage.getItem('user'));
    users.push(username);
    sessionStorage.setItem('user', JSON.stringify(users));
    

}
if(url.searchParams.get("psw")){
    var password = url.searchParams.get("psw");  
    var passwords=[];
    if (!sessionStorage.getItem('password')){
        sessionStorage.setItem('password', JSON.stringify(passwords));
    }
    passwords= JSON.parse(sessionStorage.getItem('password'));
    passwords.push(password);
    sessionStorage.setItem('password', JSON.stringify(passwords));
    }
    


if(window.location.href.split("?").length>1)
window.location.href =  window.location.href.split("?")[0]; 

function checkform(){
    username=document.getElementById("name").value;
    password=document.getElementById("pass").value;
    if (sessionStorage.getItem('user')){
        users= JSON.parse(sessionStorage.getItem('user'));
        index=users.indexOf(username);
        if (index != -1){
            passwords= JSON.parse(sessionStorage.getItem('password'));
            if(password==passwords[index]){
                sessionStorage.setItem('activeuser', JSON.stringify("True"));
                sessionStorage.setItem('username', JSON.stringify(username));
                event.preventDefault();
                window.open("./home.html","_self");
                return;  
            }else{
                event.preventDefault();
                div=document.createElement("div");
                div.innerHTML="<p style='color:red''>User Name or Password Is Incorrect</p>";
                if(document.getElementsByClassName("login")[0].childElementCount==2)
                document.getElementsByClassName("login")[0].appendChild(div)
            }
        }   
    }
    event.preventDefault();
    div=document.createElement("div");
    div.innerHTML="<p style='color:red''>User Name or Password Is Incorrect</p>";
    if(document.getElementsByClassName("login")[0].childElementCount==2)
    document.getElementsByClassName("login")[0].appendChild(div)     
}
