    var f_name = document.getElementById("uname");
    var f_letter = document.getElementById("f_letter");
    var f_capital = document.getElementById("f_capital");

    f_name.onfocus= function() { document.getElementById("f_message").style.display = "block"; }
    f_name.onblur= function() { document.getElementById("f_message").style.display = "none"; }
    f_name.onkeyup = function() 
    {
    var lowerCaseLetters = /[a-z]/g;
    if(f_name.value.match(lowerCaseLetters))
    {
    f_letter.classList.remove("invalid");
    f_letter.classList.add("valid");
    }
    else
    {
    f_letter.classList.remove("valid");
    f_letter.classList.add("invalid");
    }
    var upperCaseLetters = /[A-Z]/g;
    if(f_name.value.match(upperCaseLetters))
    {
    f_capital.classList.remove("invalid");
    f_capital.classList.add("valid");
    }
    else
    {
    f_capital.classList.remove("valid");
    f_capital.classList.add("invalid");
    }
    }

        var l_name = document.getElementById("unamel");
        var l_letter = document.getElementById("l_letter");
        var l_capital = document.getElementById("l_capital");

        l_name.onfocus= function() { document.getElementById("l_message").style.display = "block"; }
        l_name.onblur= function() { document.getElementById("l_message").style.display = "none"; }
        l_name.onkeyup = function() 
        {
        var lowerCaseLetters = /[a-z]/g;
        if(l_name.value.match(lowerCaseLetters))
        {
            l_letter.classList.remove("invalid");
            l_letter.classList.add("valid");
        }
        else
        {
            l_letter.classList.remove("valid");
            l_letter.classList.add("invalid");
        }
        var upperCaseLetters = /[A-Z]/g;
        if(l_name.value.match(upperCaseLetters))
        {
            l_capital.classList.remove("invalid");
            l_capital.classList.add("valid");
        }
        else
        {
            l_capital.classList.remove("valid");
            l_capital.classList.add("invalid");
        }
        }

            var email = document.getElementById("email");
            var e_letter = document.getElementById("e_letter");

            email.onfocus= function() { document.getElementById("e_message").style.display = "block"; }
            email.onblur= function() { document.getElementById("e_message").style.display = "none"; }
            email.onkeyup = function() 
            {
            var lowerCaseLetters = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{3,5})+$/g;
            if(email.value.match(lowerCaseLetters))
            {
            e_letter.classList.remove("invalid");
            e_letter.classList.add("valid");
            }
            else
            {
            e_letter.classList.remove("valid");
            e_letter.classList.add("invalid");
            }
            }


                var pass = document.getElementById("psw");
                var letter = document.getElementById("letter");
                var capital = document.getElementById("capital");
                var number = document.getElementById("number");
                var length = document.getElementById("length");
                var s_char = document.getElementById("special");


                pass.onfocus= function() { document.getElementById("message").style.display = "block"; }
                pass.onblur= function() { document.getElementById("message").style.display = "none"; }
                pass.onkeyup = function() 
                {
                var lowerCaseLetters = /[a-z]/g;
                if(pass.value.match(lowerCaseLetters))
                {
                    letter.classList.remove("invalid");
                    letter.classList.add("valid");
                }
                else
                {
                    letter.classList.remove("valid");
                    letter.classList.add("invalid");
                }

                var upperCaseLetters = /[A-Z]/g;
                if(pass.value.match(upperCaseLetters))
                {
                    capital.classList.remove("invalid");
                    capital.classList.add("valid");
                }
                else
                {
                    capital.classList.remove("valid");
                    capital.classList.add("invalid");
                }

                var numbers = /[0-9]/g;
                if(pass.value.match(numbers))
                {
                    number.classList.remove("invalid");
                    number.classList.add("valid");
                }
                else
                {
                    number.classList.remove("valid");
                    number.classList.add("invalid");
                }

                if(pass.value.length >= 8)
                {
                    length.classList.remove("invalid");
                    length.classList.add("valid");
                }
                else
                {
                    length.classList.remove("valid");
                    length.classList.add("invalid");
                }

                var SpecialCharacters = /[!-@#-$%-&*]/g;
                if(pass.value.match(SpecialCharacters))
                {
                    s_char.classList.remove("invalid");
                    s_char.classList.add("valid");
                }
                else
                {
                    s_char.classList.remove("valid");
                    s_char.classList.add("invalid");
                }
                }

                function myFunction() {
                    var Header = document.getElementById("h01");
                    var Header4 = document.getElementById("h44");
                    var Gender = document.getElementById("g_ender");
                    var Sign = document.getElementById("s_ign");

                    Header.classList.toggle("dark-mode");
                    Header4.classList.toggle("dark-mode");
                    Gender.classList.toggle("dark-mode");
                    Sign.classList.toggle("dark-mode");
                }
               