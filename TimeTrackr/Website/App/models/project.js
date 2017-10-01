var Project = function() {
    var pr = this;
    pr.Name = "";
    pr.GitUsername = "";
    pr.GitRepo = "";
    pr.IsGitRepo = "";
}

Project.prototype.checkGitRepo = function() {
    if (!this.IsGitRepo) {
        this.GitRepo = "";
        this.GitUsername = "";
    }
}

Project.prototype.getData = functions.getPropsByName;
Project.prototype.toPostData = functions.toPostData;