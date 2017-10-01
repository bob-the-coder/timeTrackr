var userModule = (function () {
    function register() {
        var model = new RegisterModel();
        model.getData();

        $.post("/Account/Register/",
            model.toPostData(),
            function (response) {
            debugger;
        });
    }

    function login() {
        var model = new LoginModel();
        model.getData();

        $.post("/Account/Login/",
            model.toPostData(),
            function(response) {
                debugger;
            });
    }

    return {
        register: register,
        login: login
    }
}());