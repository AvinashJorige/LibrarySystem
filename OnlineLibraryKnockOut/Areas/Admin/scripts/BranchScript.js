var branchFnc = function () {
    var self = this;
    var listData = fetchBranchList();

    this.BranchName = ko.observable();
    this.BranchId = ko.observable();
    this.successMessage = ko.observable();
    this.BranchIsActive = ko.observable();
    this.errorMessage = ko.observable();
    this.addSave = ko.observable(true);
    this.editSave = ko.observable(false);

    this.viewModel = ko.validatedObservable([
    this.BranchName.extend({
        required: {
            message: "Please enter branch name"
        }
    })]);
    this.bindingTable = ko.observable("branchLists");
    
    this.arrayObjList = ko.observableArray(listData);
    $("#branchLists").DataTable({
        responsive: true
    });
    //if (this.arrayObjList()) {
    //    $("#branchLists").DataTable();
    //}

    // Simply open the modal popup.
    this.openModal = function () {
        self.addSave(true);
        self.editSave(false);
        $('#newBranch').modal('show');
    }

    this.renderedHandler = function (elements, data) {
        if (self.arrayObjList.indexOf(data) == self.arrayObjList().length-1) {
            // Only now execute handler
            $("#branchLists").DataTable({
                responsive: true
            });
        }
    }

    //Validate the branch name textbox and fire the error event and adds the new branch name to the database.
    this.addNewBranch = function () {
        if (!this.BranchScripts.viewModel.isValid()) {
            this.BranchScripts.viewModel.errors.showAllMessages()
        }
        else {
            // on success validation add new branch to database.
            var obj = {};
            obj._branchName = this.BranchScripts.BranchName();
            obj._updationType= "add"
            var $parent = this;

            PostCallProcess("/Admin/AdminBranch/BranchModification", obj, function (params) {
                if (params.status == true) {
                    self.successMessage(params.value);
                    self.errorMessage(null);
                    var branchList = fetchBranchList();
                    var onlyInA = [];
                    var onlyInB = [];
                    onlyInA = $parent.BranchScripts.arrayObjList().filter(comparer(branchList));
                    onlyInB = branchList.filter(comparer($parent.BranchScripts.arrayObjList()));

                    $parent.BranchScripts.arrayObjList((branchList));
                    $('#newBranch').modal('hide');

                    $parent.BranchScripts.BranchName(null);
                    $parent.BranchScripts.BranchName.isModified(false);
                } else {
                    self.successMessage(null);
                    self.errorMessage(params.value);
                }
            });
        }
    }

    //Clearing all the observables
    this.clear = function () {
        this.BranchScripts.BranchName(null);
        this.BranchScripts.BranchName.isModified(false);
    }

    // Used to open the modal popup and bind the row details to observables.
    this.bindEditingBranch = function (branchInfo) {
        self.editSave(true);
        self.addSave(false);
        self.BranchName(branchInfo.BrchName);
        self.BranchId(branchInfo.BrchId);

        // Appending the branch name when modal popup opens
        $('#newBranch').modal('show');
    };

    // Used for updating the model and database
    this.editBranch = function () {

        if (!this.BranchScripts.viewModel.isValid()) {
            this.BranchScripts.viewModel.errors.showAllMessages()
        }
        else {
            // on success validation add new branch to database.
            var $parent = this;

            var obj = {};
            obj._branchName = self.BranchName();
            obj._branchId = self.BranchId();
            obj._updationType = "update";

            // updating in the database.
            PostCallProcess("/Admin/AdminBranch/BranchModification", obj, function (params) {
                if (params.status == true) {
                    self.successMessage(params.value);
                    self.errorMessage(null);
                    var branchList = fetchBranchList();

                    self.arrayObjList((branchList));
                    $('#newBranch').modal('hide');

                    self.BranchName(null);
                    self.BranchName.isModified(false);
                } else {
                    self.successMessage(null);
                    self.errorMessage(params.value);
                }
            });
        }
    }

    // This is used for archive the branch which in general make the active false;
    this.archiveBranch = function (branchInfo) {
        self.BranchName(branchInfo.BrchName);
        self.BranchId(branchInfo.BrchId);

        var obj = {};
        obj._branchName = self.BranchName();
        obj._branchId = self.BranchId();
        obj._updationType = "updateDelete";

        // updating in the database.
        PostCallProcess("/Admin/AdminBranch/BranchModification", obj, function (params) {
            if (params.status == true) {
                self.successMessage(params.value);
                self.errorMessage(null);
                var branchList = fetchBranchList();
                self.arrayObjList((branchList));
            } else {
                self.successMessage(null);
                self.errorMessage(params.value);
            }
        });

    };

    // This is used for activating the branch which in general make the active true
    this.activeBranch = function (branchInfo) {
        self.BranchName(branchInfo.BrchName);
        self.BranchId(branchInfo.BrchId);

        var obj = {};
        obj._branchName = self.BranchName();
        obj._branchId = self.BranchId();
        obj._updationType = "update";

        // updating in the database.
        PostCallProcess("/Admin/AdminBranch/BranchModification", obj, function (params) {
            if (params.status == true) {
                self.successMessage(params.value);
                self.errorMessage(null);
                var branchList = fetchBranchList();
                self.arrayObjList((branchList));
            } else {
                self.successMessage(null);
                self.errorMessage(params.value);
            }
        });

    };


    // This is used for deleting the branch which in general make the active false;
    this.deleteBranch = function (branchInfo) {
        self.BranchName(branchInfo.BrchName);
        self.BranchId(branchInfo.BrchId);

        var obj = {};
        obj._branchName = self.BranchName();
        obj._branchId = self.BranchId();
        obj._updationType = "delete";

        // updating in the database.
        PostCallProcess("/Admin/AdminBranch/BranchModification", obj, function (params) {
            if (params.status == true) {
                self.successMessage(params.value);
                self.errorMessage(null);
                var branchList = fetchBranchList();
                self.arrayObjList((branchList));
            } else {
                self.successMessage(null);
                self.errorMessage(params.value);
            }
        });

    };



}

function comparer(otherArray) {
    return function (current) {
        return otherArray.filter(function (other) {
            return other.BrchName == current.BrchName && other.BrchId == current.BrchId && other.BksTotal == current.BksTotal && other.StdTotal == current.StdTotal;
        }).length == 0;
    }
}

var bindProperties = function (BrchName, BrchId, BksTotal, StdTotal) {
    var self = this;
    self.BrchName = BrchName;
    self.BrchId = BrchId;
    self.BksTotal = BksTotal;
    self.StdTotal = StdTotal;
}

function fetchBranchList() {
    var arrayObjList = [];

    PostCallProcess("/Admin/AdminBranch/BranchList", { empty: "" }, function (params) {

        var result = JSON.parse(params);
        var objList = {};

        if (result.BranchList) {
            result.BranchList.filter(function (brchName) {
                objList = {};
                // Capture the branch name and Id
                objList.BrchName = brchName.BranchName;
                objList.BrchId = brchName.BranchID;
                objList.BrchIsActive = brchName.isActive;

                // Capture total number of books per branch
                objList.BksTotal = 0;
                if (result.BookList) {
                    result.BookList.filter(function (bkName) {
                        if (brchName.BranchName == bkName.Branch) {
                            objList.BksTotal++;
                        }
                    });
                }

                //Capture total number of students per branch
                objList.StdTotal = 0;
                if (result.StudentList) {
                    result.StudentList.filter(function (stdName) {
                        if (brchName.BranchName == stdName.BranchName) {
                            objList.StdTotal++;
                        }
                    });
                }
              //  if (objList.BrchIsActive) {
                    arrayObjList.push(objList);
               // }
            });
        }
    });

    return arrayObjList;
}

$(document).ready(function () {

    //$("#branchLists").dynatable();
});