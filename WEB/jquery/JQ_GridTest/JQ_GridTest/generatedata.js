function generatedata(rowscount, hasNullValues) {
    // prepare the data
    var data = new Array();
    if (rowscount == undefined) rowscount = 100;
    var firstNames =
    [
        "Andrew", "Nancy", "Shelley", "Regina", "Yoshi", "Antoni", "Mayumi", "Ian", "Peter", "Lars", "Petra", "Martin", "Sven", "Elio", "Beate", "Cheryl", "Michael", "Guylene"
    ];

    var lastNames =
    [
        "Fuller", "Davolio", "Burke", "Murphy", "Nagase", "Saavedra", "Ohno", "Devling", "Wilson", "Peterson", "Winkler", "Bein", "Petersen", "Rossi", "Vileid", "Saylor", "Bjorn", "Nodier"
    ];

    var productNames =
    [
        "Black Tea", "Green Tea", "Caffe Espresso", "Doubleshot Espresso", "Caffe Latte", "White Chocolate Mocha", "Caramel Latte", "Caffe Americano", "Cappuccino", "Espresso Truffle", "Espresso con Panna", "Peppermint Mocha Twist"
    ];

    var priceValues =
    [
         "2.25", "1.5", "3.0", "3.3", "4.5", "3.6", "3.8", "2.5", "5.0", "1.75", "3.25", "4.0"
    ];

    for (var i = 0; i < rowscount; i++) {
        var row = {};
        var productindex = Math.floor(Math.random() * productNames.length);
        var price = parseFloat(priceValues[productindex]);
        var quantity = 1 + Math.round(Math.random() * 10);

        row["id"] = i;
        row["available"] = productindex % 2 == 0;
        if (hasNullValues == true) {
            if (productindex % 2 != 0) {
                var random = Math.floor(Math.random() * rowscount);
                row["available"] = i % random == 0 ? null : false;
            }
        }
        row["firstname"] = firstNames[Math.floor(Math.random() * firstNames.length)];
        row["lastname"] = lastNames[Math.floor(Math.random() * lastNames.length)];
        row["name"] = row["firstname"] + " " + row["lastname"]; 
        row["productname"] = productNames[productindex];
        row["price"] = price;
        row["quantity"] = quantity;
        row["total"] = price * quantity;

        var date = new Date();
        date.setFullYear(2013, Math.floor(Math.random() * 11), Math.floor(Math.random() * 27));
        date.setHours(0, 0, 0, 0);
        row["date"] = date;
       
        data[i] = row;
    }

    return data;
}

function retriveProduct(categoryId) {
    var svcRootPath = Getrootpath("/service/wcf_service.svc");
    varUrl = svcRootPath + "/RetriveProducts";
    varData = '{"categoryId": "' + categoryId + '"}';
    $.ajax({
        type: "POST", 
        url: varUrl, 
        data: varData, 
        contentType: "application/json; charset=utf-8",
        dataType: "json", 
        processdata: true, 
        success: function (data) {

            ServiceSucceeded(data);
        },
        error: ServiceFailed
    });

}




function OnRetriveCategories_Succeeded(result) {
    var theme = getDemoTheme();
    var data = new Array();
    var totalprice = 0;
    var list = result.RetriveCategoriesResult;
    var data = list;

    // prepare the data
    var source =
                {
                    datatype: "json",
                    datafields: [
                        { name: 'Id' },
                        { name: 'ParentId' },
                        { name: 'Text' },
                        { name: 'Value' }
                    ],
                    id: 'Id',
                    localdata: data
                };

    // create data adapter.
    var dataAdapter = new $.jqx.dataAdapter(source);
    // perform Data Binding.
    dataAdapter.dataBind();
    // get the tree items. The first parameter is the item's id. The second parameter is the parent item's id. The 'items' parameter represents 
    // the sub items collection name. Each jqxTree item has a 'label' property, but in the JSON data, we have a 'text' field. The last parameter 
    // specifies the mapping between the 'text' and 'label' fields.  
    var records = dataAdapter.getRecordsHierarchy('Id', 'ParentId', 'items', [{ name: 'Text', map: 'label'}]);

    // Create jqxExpander


   $('#jqxTree').jqxTree({ source: records, width: '300px', theme: theme });

//    $("#jqxTree")
//      .jqxTree({ "plugins": ["themes", "html_data", "ui"] })
//        .bind("select_node.jstree", function (event, data) {
//            alert(data.rslt.obj.attr("id"));
//        }
//            ).delegate("a", "click", function (event, data) { event.preventDefault(); })

}

function ServiceFailed(result) {
    alert('Service call failed: ' + result.status + '' + result.statusText);

}