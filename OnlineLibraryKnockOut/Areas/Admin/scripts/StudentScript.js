var StudentInfo = function () {
    var self = this;
    this.errorMessage = ko.observable(false);
    this.successMessage = ko.observable(false);

    // initialize the observables 
    this.stdName = ko.observable();
    this.stdBranchList = ko.observableArray([]);
    this.stdStudentList = ko.observableArray([]);
    this.stdBranch = ko.observable();
    this.stdFilterBranch = ko.observable("All");
    this.stdGender = ko.observable();
    this.stdDob = ko.observable();
    this.stdMobile = ko.observable();
    this.stdAddress = ko.observable();
    this.stdCity = ko.observable();
    this.stdPinCode = ko.observable();
    this.stdPhoto = ko.observable();
    this.stdEmail = ko.observable();
    this.stdPassword = ko.observable();
    this.stdId = ko.observable();
    this.stdEntryDate = ko.observable();
    this.stdPhotoVisible = ko.observable(false);
    this.stdFilterStatus = ko.observable("All");

    this.viewModel = ko.validatedObservable([
        // form label Items list : 
        this.stdName.extend({
            required: {
                message: "Enter the student name"
            }
        }),
        this.stdBranchList = ko.observableArray([]),
        this.stdBranch.extend({
            required: {
                message: "Select the branch."
            }
        }),
        this.stdGender.extend({
            required: {
                message: "Choose the gender"
            }
        }),
        this.stdDob.extend({
            required: {
                message: "Enter the Date of Birth"
            }
        }),
        this.stdMobile.extend({
            required: true,
            pattern: {
                message: 'Invalid phone number.',
                params: /^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$/
            }
        }),
        this.stdAddress.extend({
            required: {
                message: "Enter the Address"
            }
        }),
        this.stdCity.extend({
            required: {
                message: "Enter the city."
            }
        }),
        this.stdPinCode.extend({
            required: {
                message: "Enter the valid pincode"
            }
        }),
        this.stdPhoto.extend({
            required: {
                message: "Upload the photo."
            }
        }),
        this.stdEmail.extend({
            required: {
                message: "Email is Required."
            },
            pattern: {
                message: 'Invalid email address.',
                params: /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
            }
        }),
        this.stdPassword.extend({
            required: {
                message: "Enter valid password"
            }
        })
    ]);

    this.statusFilterList = ko.observableArray([
        {
            "filterName": "All",
            "filterValue": "All"
        },
        {
            "filterName": "Active",
            "filterValue": true
        },
        {
            "filterName": "In Active",
            "filterValue": false
        }
    ]);



    var StudentBindingJSON = function (param) {
        var _stdInfo = {
            "StudentName": param.stdName(),
            "BranchName": param.stdBranch().BranchName,
            "Mobile": param.stdMobile(),
            "Address": param.stdAddress(),
            "City": param.stdCity(),
            "Pincode": param.stdPinCode(),
            "DOB": param.stdDob(),
            "Gender": param.stdGender(),
            "Email": param.stdEmail(),
            "Password": param.stdPassword(),
            "Image": param.stdPhoto()
        }
        return _stdInfo;
    }


    self.isValid = ko.computed(function () {
        return this.viewModel.isValid();
    }, this);

    self.uploadImage = function (obj, event) {
        cloudinary.openUploadWidget({
            cloud_name: 'dbqnukuxd',
            upload_preset: 'ImageUploadUnSigned',
            folder: "Library_System",
            client_allowed_formats: ["png", "gif", "jpeg"],
            max_file_size: 5000000,
            show_powered_by: false,
            multiple: false,
            sources: ["local"]
        },
        function (error, result) {
            console.log(result);
            if (result && error == null) {
                self.stdPhoto(result[0].secure_url);
                self.stdPhotoVisible(true);
            }
        });
    }

    self.selectBranch = function (obj, event) {
        if (event.target.selectedIndex > 0) {
            this.StudentScripts.stdBranch(event.target.selectedOptions[0].label);
        }
    };

    self.filterStatus = function (obj, event) {
        if (event.target.selectedIndex >= 0) {
            this.StudentScripts.stdFilterStatus(event.target.selectedOptions[0].label);
            if (event.target.selectedOptions[0].label == "All")
                bindStudentList(self, 'All', false, 'isActive');
            if (event.target.selectedOptions[0].label == "Active")
                bindStudentList(self, true, true, 'isActive');
            if (event.target.selectedOptions[0].label == "In Active")
                bindStudentList(self, false, false, 'isActive');
        }
        $('.table-search').load().tablePaginate({ navigateType: 'full', fullData: false, buttonPosition: 'after', navigateType: 'navigator', recordPerPage: 10 });
    };

    this.filterBranch = function (obj, event) {
        if (event.target.selectedIndex >= 0) {
            this.StudentScripts.stdFilterBranch(event.target.selectedOptions[0].label);
            bindStudentList(self, event.target.selectedOptions[0].label, null, 'BranchName');
        }
        $('.table-search').load().tablePaginate({ navigateType: 'full', fullData: false, buttonPosition: 'after', navigateType: 'navigator', recordPerPage: 10 });
    };


    this.isValidForm = function () {
        var re = new StudentBindingJSON(this.StudentScripts);
        // possible other logic
        if (!this.StudentScripts.viewModel.isValid()) {
            this.StudentScripts.viewModel.errors.showAllMessages()
        }
        else {
            var obj = {};
            obj._updationType = "add";
            obj._stdInfo = re;
            $parent = this;
            PostCallProcess("/Admin/AdminStudentInfo/StudentInfoAPI", obj, function (params) {
                if (params.status == true) {
                    self.successMessage(params.value);
                    self.errorMessage(null);
                    $parent.StudentScripts.onFormReset();
                } else {
                    self.successMessage(null);
                    self.errorMessage(params.value);
                }
            })
        }
    };

    this.onFormReset = function () {
        //Your custom logic to notify or reset your specific fields.
        for (var o in this) {
            if (o.indexOf('std') > -1) {
                if (this[o].clearError) {
                    this[o](null);
                    this[o].clearError();
                }
                this['stdPhotoVisible'](false);
            }
        }
        bindBrachList(self);
        return this.viewModel.isValid();
    }

    this.reloadDatatable = function () {
        bindStudentList(self, null);
        $('.table-search').load().tablePaginate({ navigateType: 'full', fullData: false, buttonPosition: 'after', navigateType: 'navigator', recordPerPage: 10 });
    }

    bindBrachList(self);
    bindStudentList(self, null);
}

function bindBrachList(self) {
    var obj = {};
    obj._updationType = "getBranch";

    //post call to the server to bind the branch name list.
    PostCallProcess("/Admin/AdminBranch/BranchModification", obj, function (params) {
        if (params.status == true) {
            var branchList = JSON.parse(params.value);
            self.stdBranchList([]);
            branchList.filter(function (d) {
                if (d.isActive) {
                    self.stdBranchList.push(new branches(d.BranchName, d.BranchID));
                }
            });
        } else {
            self.successMessage(null);
            self.errorMessage(params.value);
        }
    })
}

//self, labelvalue, bindingActiveRecords, filterBy
function bindStudentList(self, filter, isActive, filterBy) {
    if (isActive == undefined) {
        isActive = null;
    }
    var obj = {};
    obj._updationType = "getStudent";


    //post call to the server to bind the student list.
    PostCallProcess("/Admin/AdminStudentInfo/StudentInfoAPI", obj, function (params) {
        if (params.status == true) {
            var studentList = JSON.parse(params.value);
            self.stdStudentList([]);
            ko.utils.arrayFilter(studentList, function (d) {
                bindingStdList(self, filter, isActive, filterBy, d)
            });
        } else {
            self.successMessage(null);
            self.errorMessage(params.value);
        }
    })

    if (self.stdFilterStatus() == "All") {
        filter = 'All';
        isActive = false;
        filterBy = 'isActive';
    }

    if (self.stdFilterBranch() != "All" || self.stdFilterStatus() != "All") {
        if (self.stdFilterStatus() == 'Active') {
            isActive = true;
        }
        else if (self.stdFilterStatus() == 'In Active') {
            isActive = false;
        }

        if (self.stdFilterStatus() == "Active") {
            filter = true;
            isActive = true;
            filterBy = 'isActive';
        }

        if (self.stdFilterStatus() == "In Active") {
            filter = false;
            isActive = false;
            filterBy = 'isActive';
        }
    }    
    var count = self.stdStudentList().length;

    if (self.stdFilterStatus() && self.stdFilterStatus() != "All") {
        var data = JSON.parse(JSON.stringify(self.stdStudentList()));
        self.stdStudentList([]);
        ko.utils.arrayFilter(data, function (d) {
            bindingStdList(self, filter, isActive, filterBy, d)
        });
    }
    count = self.stdStudentList().length;

    if (self.stdFilterBranch() && self.stdFilterBranch() != "All") {
        var data = JSON.parse(JSON.stringify(self.stdStudentList()));
        branch = self.stdFilterBranch().BranchName || self.stdFilterBranch();
        self.stdStudentList([]);
        ko.utils.arrayFilter(data, function (d) {
            bindingStdList(self, branch, null, 'BranchName', d)
        });
    }
    count = self.stdStudentList().length;
}

function bindingStdList(self, filter, isActive, filterBy, d) {
    if (!isActive) {
        if (!filter && filter != 'All' && isActive) {
            bindingStdListHelper(self, d)
        } else if ((filter == d[filterBy] && !isActive) || filter == 'All') {
            bindingStdListHelper(self, d)
        }
        else if (filter == d[filterBy] || filter == 'All') {
            bindingStdListHelper(self, d)
        }
    }
    else if (d.isActive == isActive) {
        if (!filter && filter != 'All') {
            bindingStdListHelper(self, d)
        } else if (filter == d[filterBy] || filter == 'All') {
            bindingStdListHelper(self, d)
        }
    }
}

function bindingStdListHelper(self, d) {
    for (var i in d) {
        if ((i == "EntryDate" || i == 'DOB')) {
            d[i] = convertDate(d[i]);
        }
    }
    self.stdStudentList.push(d);
}

function convertDate(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(inputFormat);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
}

var branches = function (name, id) {
    this.BranchName = name;
    this.BranchID = id;
};


function autoToggle(data, event) {
    $(".autoSlideUp").css("display", "none");
    if (data.SID) {
        if ($("#autoHide_" + data.SID).attr('class').indexOf('hide') > -1) {
            $("#autoHide_" + data.SID).removeClass('hide').css("display", "table-row");
        } else {
            $("#autoHide_" + data.SID).addClass('hide').css("display", "none");
        }
    }
}


$(document).ready(function () {

})

$(function () {
    $('#toggle-two').bootstrapToggle({
        on: 'Active',
        off: 'In Active'
    });
})