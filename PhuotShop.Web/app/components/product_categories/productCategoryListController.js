(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.selectAllProductCategories = selectAllProductCategories;
        $scope.isAll = false;
        $scope.deleteMultipleProductCategories = deleteMultipleProductCategories;

        function deleteMultipleProductCategories() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedProductCategories: JSON.stringify(listId)
                }
            }
            apiService.del('api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }

        function selectAllProductCategories() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        // Kiểm tra check box của category đã được check hay chưa để disable or enable của nút Xóa
        $scope.$watch('productCategories', function (newValue, oldValue) {
            var checked = $filter('filter')(newValue, { checked: true });
            if (checked.length) {
                $scope.selected = checked;                
                $('#btnDelete').removeAttr('disabled');
            }
            else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function search() {
            getProductCategories();
        }

        function deleteProductCategory(id) {
            debugger;
            $ngBootbox.confirm('Bạn có chắc muốn xóa không?').then(function () {
                var config = {
                    params: {
                        id : id
                    }
                }
                apiService.del('api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }
        
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 5
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!');
                }
                //else {
                //    notificationService.displaySuccess('Có ' + result.data.TotalCount + ' bản ghi được tìm thấy!');
                //}
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product category failed!');
            });
        }

        $scope.getProductCategories();
    }
})(angular.module('phuotshop.product_categories'));