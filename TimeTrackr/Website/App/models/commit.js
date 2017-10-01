var Commit = function() {
    var self = this;
    self.ProjectId = "";
    self.From = "";
    self.To = "";
    self.Description = "";
}

Commit.prototype.getData = functions.getPropsByName;
Commit.prototype.toPostData = functions.toPostData;