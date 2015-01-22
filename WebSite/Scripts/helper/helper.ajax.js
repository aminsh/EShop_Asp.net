var helper = helper || {};

$(function () {

    //amplify.request.define("getEnum", "ajax", {
    //    url: window.getFullPath("api/Enum/GetEnums/{enum}"), 
    //    type: "GET",
    //    dataType: "json",
    //    cache: "persist"
    //});
    
    amplify.request.define("addToBasket", "ajax", {
        url: "/api/OrderDetail",
        type: "POST",
        dataType: "json",
        cache: "persist"
    });
    
    helper.ajax = (function () {
        var get = function(resouseId,enumName,callback) {
            amplify.request(resouseId, { enum: enumName }, callback);
        },
        post = function (resouseId,data,callback) {
            // amplify.request(resouseId, { data: data }, callback);
            //amplify.request({
            //    resourceId: resouseId,
            //    data: data,
            //    success: callback.success,
            //    error: callback.error
            //});
            
            $.ajax("/api/OrderDetail", {
                dataType: "json",
                contentType: "application/json",
                cache: false,
                type: "POST",
                data: data,
                success: callback.success,
                error: callback.error
            });
        }

        
        return {
            get: get,
            post: post
        };
    })();
});