'use strict'

lotteryApp.service('dataService', ['$http',function ($http) {
    this.getNumbers = function () {
        $http({
            method: "GET",
            url: "numbers"
        }).success(function (data) {
            return data;
        });
        
    };
}])

lotteryApp.factory('dataServiceFac', function ($http) {
    var dataServiceFac = {
        numbers: function () {
            var promise = $http.get('numbers').then(function (response) {
                console.log(response);
                return response.data;
            });
            // Return the promise to the controller
            return promise;
        },
       saveNumbers: function(data){
           var promise = $http.post('saveNumber',data).then(function (response) {
               console.log(response);
               return response.data;
           })
           return promise;
       }

    };
    return dataServiceFac;
});