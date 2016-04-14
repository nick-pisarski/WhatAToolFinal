namespace WhatAToolFinal.Controllers {

    export class MainController {
        public toolList;
        public userList;
        public sortType = 'toolName';
        public sortReverse = false;

        constructor(private $http: ng.IHttpService) {
            this.getToolList();
            this.getUserList();
        }
        public getToolList() {
            this.$http.get('/api/tools')
                .then((response) => {

                    this.toolList = response.data;
                })
                .catch((response) => {
                    console.error('Failed to retrieve list of tools.');
                });
        }
        public getUserList() {
            this.$http.get('/api/ApplicationUser')
                .then((response) => {
                    this.userList = response.data;
                })
                .catch((response) => {
                    console.error('Failed to retrieve list of tools.');
                });
        }

    }

    export class ToolDetailController {
        public tool;
        public likeTools; //a list of all the tools that are the same category

        public checkOut() {
            var t = {
                toolId: this.tool.id,
                
            };
            console.log(t);
            this.$http.put('api/tools/checkOut', t)
                .then((r) => {
                    this.$state.go('main')
                });

        };

        public getLikeTools() {
            console.log(this.tool.category);
            this.$http.get(`/api/tools/category/${this.tool.category}`)
                .then((response) => {
                    this.likeTools = response.data;
                })
                .catch((response) => {
                    console.error('Failed to retrieve list of tools.');
                });

        };

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.$http.get(`/api/tools/${this.$stateParams['id']}`)
                .then((response) => {
                    this.tool = response.data;
                    this.getLikeTools();
                })
                .catch((response) => {
                    console.error('Failed to retrieve list of tools.');
                });
        }
    }

    export class ProfileDetailController {
        public user;
        public toolList

        public returnTool(id) {
            // Prompts, checks and ensures the user has entered a number NEEDS some work having issues with 3.0
            var mh = prompt("Please enter the machine hours.", "ex. 4.5");
            while (parseFloat(mh).toString() !== mh) {
                mh = prompt("Please enter the machine hours.", "you must enter an number");
            }
            //put request to change status and machine hours
            this.$http.put('api/tools/return', {
                userId: this.user.id,
                toolId: id,
                machineHours: parseFloat(mh),
                status: 'Available',
            })
                .then((r) => {
                    this.$state.go('main')
                });                
            //remove from this.user.toolList (prevents from having to call an extra get to update current list)
            
            
            console.log("Tool Returned");
        };
        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.$http.get(`/api/ApplicationUser/userBy/${this.$stateParams['id']}`)
                .then((response) => {
                    
                    this.user = response.data;
                    this.toolList = this.user.tools;
                    
                })

        }

    }

    export class AdminListController {
        public userList;
        public toolList;

        constructor(private $http: ng.IHttpService) {
            //get userLsit and toolList
            this.getToolList();
            this.getUserList();
        }

        public getToolList() {
            this.$http.get('/api/tools')
                .then((response) => {

                    this.toolList = response.data;
                })
                .catch((response) => {
                    console.error('Failed to retrieve list of tools.');
                });
        }
        public getUserList() {
            this.$http.get('/api/ApplicationUser')
                .then((response) => {
                    this.userList = response.data;
                })
                .catch((response) => {
                    console.error('Failed to retrieve list of tools.');
                });
        }

    }

  
    
}
