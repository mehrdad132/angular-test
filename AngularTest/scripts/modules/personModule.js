(
    function () {
        angular.module('personModule', [])
        .controller('personController', function ($scope, $http) {
            $http.post('/Home/LoadPerson')
            .then(function (result) {
                $scope.person = [];
              $scope.person = result.data;
       
            });
          

               $scope.SavePerson = function () {
                $http.post('/Home/AddPerson', { Name: $scope.Name, Family: $scope.Family, Age: $scope.Age })
                .then(function (result) {
                    $scope.alert = "ثبت نام با موفقیت انجام شد"
                    $scope.person = result.data;
                    $scope.Name = '';
                    $scope.Family = '';
                    $scope.Age = '';
                });
            };
            $scope.DeletePerson = function (ID) {
                $http.get('/Home/Delete/' + ID)
                .then(function (res) {
                    $scope.person = res.data;
                });

            };
     

        });
    }

)();
