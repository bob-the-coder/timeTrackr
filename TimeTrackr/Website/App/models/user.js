var User = function(user) {
    var self = this;
    self.Id = user.Id || constants.GuidEmpty;
    self.Email = user.Email || "";
    self.FullName = user.FullName || "";
}

var LoginModel = function() {
    var self = this;
    self.Email = "";
    self.Password = "";
}

LoginModel.prototype.getData = functions.getPropsByName;
LoginModel.prototype.toPostData = functions.toPostData;

var RegisterModel = function() {
    var self = this;
    self.Email = "";
    self.Password = "";
    self.ConfirmPassword = "";
}

RegisterModel.prototype.getData = functions.getPropsByName;
RegisterModel.prototype.toPostData = functions.toPostData;