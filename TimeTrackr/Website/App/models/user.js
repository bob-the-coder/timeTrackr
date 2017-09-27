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

LoginModel.prototype.getDataFromView = functions.getPropsByName;