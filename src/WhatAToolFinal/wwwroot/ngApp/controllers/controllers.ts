namespace WhatAToolFinal.Controllers {

    export class MainController {
        public toolList;
        public userList;

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

        public getLikeTools() {
            console.log(this.tool.category);
            this.$http.get(`/api/tools/category/${this.tool.category.name}`)
                .then((response) => {
                    this.likeTools = response.data;
                })
                .catch((response) => {
                    console.error('Failed to retrieve list of tools.');
                });

        };

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
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

        public returnTool(id) {
            //popup or new page to get machine hours/?notes
            //put request to change status
            //put request to remove from user toolList
            //remove from this.user.toolList (prevents from having to call an extra get to update current list)
            //on submit go to user page
            console.log("Tool Returned");
        };
        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
            this.$http.get(`/api/ApplicationUser/userBy/${this.$stateParams['id']}`)
                .then((response) => {
                    this.user = response.data;
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

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }
    
}
