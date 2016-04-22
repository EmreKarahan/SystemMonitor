var ItemManager = function () {

    var updateCallCountUrl = "/Home/UpdateCallCount";
    var updateAllowBackUrl = "/Home/UpdateAllowBack";
    var updatePriceUrl = "/Home/UpdatePrice";
    var updateStatusUrl = "/Home/UpdateStatus";

    return {
        updateCallCount: function (itemId) {
            AjaxManager.Ajax(updateCallCountUrl, RequestType.GET, DataType.HTML, { itemId: itemId }, function (data, status, xhr) {
                $("#callCount_" + itemId).text(data);
            });
        },
        updateAllowBack: function (itemId, obj) {
            AjaxManager.Ajax(updateAllowBackUrl, RequestType.GET, DataType.HTML, { itemId: itemId, status: obj.checked });
        },
        updatePrice: function (itemId) {
            var rowData = $('tr[rel="row_' + itemId + '"]');
            var priceData = $("#item_Price", rowData);
            AjaxManager.Ajax(updatePriceUrl, RequestType.GET, DataType.HTML, { itemId: itemId, price: priceData.val() });
        },
        updateStatus: function (itemId) {
            AjaxManager.Ajax(updateStatusUrl, RequestType.GET, DataType.HTML, { itemId: itemId });
        }
    }
}();