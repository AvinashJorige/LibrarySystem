var StudentInfo = function(){
    var self = this;
    self.errorMessage = ko.observable(false);
    self.successMessage = ko.observable(false);
    

    self.bindFormStudent = ko.observableArray([]);


}