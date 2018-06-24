(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService', '$stateParams'];

    function productEditController($scope, apiService, notificationService, $state, commonService, $stateParams) {
        $scope.product = {}

        $scope.updateProduct = updateProduct;
        $scope.GetSeoTitle = GetSeoTitle;

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '500px'
        }
        
        $scope.moreImages = [];        

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function loadProductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function updateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.put('/api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công.');
            });
        }

        function loadProductCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get list parent category.')
            });
        }

        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        
        $scope.chooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }

        loadProductCategory();
        loadProductDetail();
    }
})(angular.module('phuotshop.products'));