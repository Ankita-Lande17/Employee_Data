    $(document).ready(function() {
        //to allow only numberic  
        $('#Contact').keypress(function (e) {
            NumericOnly(e);
        });  
    });
$("#btn-signup").click(function () {
    alert(1);
    ValidateUser();
})
    //to check all fields where user enter correct or not   
    // if not entered correct ,it will prevent to sumbit form  
    function ValidateUser() {
        event = event || window.event || event.srcElement;
    var return_val = true;
    if ($('#FirstName').val().trim() == '') {
        $('#FirstName').next('span').show();
    return_val = false;  
        } else {
        $('#FirstName').next('span').hide();  
        }
    if ($('#LastName').val().trim() == '') {
        $('#LastName').next('span').show();
    return_val = false;  
        } else {
        $('#LastName').next('span').hide();  
        }
    if ($('#Email').val().trim() == '') {  
        $('#Email').next('span').text('Please enter Email').show();
    return_val = false;  
        } else {
        $('#Email').next('span').hide();
    if (fnValidateEmail($('#Email').val().trim()) == false) {
        $('#Email').next('span').text('Please enter valid Email').show();
    return_val = false;  
            } else {
        $('#Email').next('span').text('Please enter Email').hide();  
            }  
        }
    if ($('#Password').val().trim() == '') {
        $('#Password').next('span').show();
    return_val = false;  
        } else {
        $('#Password').next('span').hide();
    if (PasswordStrengthCheck($('#Password').val().trim()) == false) {
        return_val = false;  
            }  
        }
    if ($('#Contact').val().trim() == '') {
        $('#Contact').next('span').show();
    return_val = false;  
        } else {
        $('#Contact').next('span').hide();  
        }
    if (!return_val) {
        event.preventDefault();  
        }  
    }
    // to check password strength   
    function PasswordStrengthCheck(password) {  
        var return_val = true;
    if (password != '') {  
            if (password.length < 8) {
        $('#Password').next('span').text('Be at least 8 characters').show();
    $('#Password').focus();
    return_val = false;  
            } else if (!password.match(/[A-z]/)) {
        $('#Password').next('span').text('At least one letter').show();
    $('#Password').focus();
    return_val = false;  
            } else if (!password.match(/[A-Z]/)) {
        $('#Password').next('span').text('At least one uppercase alphabet').show();
    $('#Password').focus();
    return_val = false;  
            } else if (!password.match(/[a-z]/)) {
        $('#Password').next('span').text('At least one lowercase alphabet').show();
    $('#Password').focus();
    return_val = false;  
            } else if (!password.match(/\d/)) {
        $('#Password').next('span').text('At least one number').show();
    $('#Password').focus();
    return_val = false;  
            } else if (!password.match(/[ !@#$%^&*()_+\-=\[\]{ };':"\\|,.<>\/?]/)) {
        $('#Password').next('span').text('At least one special character').show();
        $('#Password').focus();
        return_val = false;  
            } else {
            $('#Password').next('span').text('').hide();  
            }  
        } else {
            $('#Password').next('span').text('Please enter Password').show();
        return_val = false;  
        }
        return return_val;  
    };
        // to check email formate   
        function fnValidateEmail(email) {  
        var expr = /^([\w-\.]+)@((\[[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\.)|(([\w-]+\.)+))([a-zA-Z]{2, 4}|[0-9]{1, 3})(\]?)$/;
        return expr.test(email);  
    };

        function NumericOnly(e) {  
        var regex = new RegExp("^[0-9]+$");
        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (regex.test(str)) {  
            return true;  
        }
        e.preventDefault();
        return false;  
    };
  