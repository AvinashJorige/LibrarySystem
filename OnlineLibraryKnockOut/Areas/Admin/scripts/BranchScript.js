ko.validation.rules.pattern.message = 'Invalid.';
ko.validation.init({
    messageTemplate: null,
    errorElementClass: 'has-error',
    errorMessageClass: 'help-block',
    decorateInputElement: true
}, true);

var branchFnc = function () {
    var self = this;
    this.BranchName = ko.observable();
    this.successMessage = ko.observable();
    this.errorMessage = ko.observable();

    this.viewModel = ko.validatedObservable([
    this.BranchName.extend({
        required: {
            message: "Please enter branch name"
        }
    })]);


    this.validate = function () {
        if (!this.BranchScripts.viewModel.isValid()) {
            this.BranchScripts.viewModel.errors.showAllMessages()
        }
        else {
            // on success validation add new branch to database.
            var obj = {};
            obj._branchName = this.BranchScripts.BranchName();
            var $parent = this;

            PostCallProcess("/Admin/AdminBranch/newBranch", obj, function (params) {
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

    this.clear = function () {
        this.BranchScripts.BranchName(null);
        this.BranchScripts.BranchName.isModified(false);
    }
//}

//var branchListFnc = function () {
    // var self = this;

    var listData = fetchBranchList();
    this.arrayObjList = ko.observableArray();
    this.arrayObjList(listData);
    $("#branchLists").DataTable();

    this.EditForm = function (branchInfo) {
        alert(JSON.stringify(branchInfo));
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

                //arrayObjList.push(new bindProperties(objList.BrchName, objList.BrchId, objList.BksTotal, objList.StdTotal));
                arrayObjList.push(objList);
            });
        }
    });

    return arrayObjList;
}

$(document).ready(function () {

    //$("#branchLists").dynatable();
});