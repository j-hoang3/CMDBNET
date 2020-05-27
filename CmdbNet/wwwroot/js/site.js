$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {


        var valid = true;
        var min = moment($("#txtMin").val());
        if (!min.isValid()) { min = null; }

        var max = moment($("#txtMax").val());
        if (!max.isValid()) { max = null; }

        if (min === null && max === null) {
            // no filter applied or no date columns
            valid = true;
        }
        else {

            $.each(settings.aoColumns, function (i, col) {

                if (col.mData == "modified") {
                    var cDate = moment(data[i]);

                    if (cDate.isValid()) {
                        if (max !== null && max.isBefore(cDate)) {
                            valid = false;
                        }
                        if (min !== null && cDate.isBefore(min)) {
                            valid = false;
                        }
                    }
                    else {
                        valid = false;
                    }
                }
            });
        }
        return valid;
    });



$(document).ready(function () {

    // Date Range Filter

    $("#date_index").click(function () {
        $('#items_table').DataTable().draw();
    });

    $("#date_missing").click(function () {
        $('#custodian_missing_items_table').DataTable().draw();
    });

    $("#date_hardware").click(function () {
        $('#my_items_table').DataTable().draw();
    });

    $("#date_discrepancies").click(function () {
        $('#missing_items_table').DataTable().draw();
    });

    $("#date_custodian").click(function () {
        $('#custodian_items_table').DataTable().draw();
    });

    var items_table = $("#items_table").DataTable({
        "ajax": {
            type: "GET",
            url: "/?handler=List",
            serverSide: true,
            dataSrc: "",
            contentType: "application/json",
            dataType: "json",
        },
        "searchPane": {
            columns: [2, 4, 5, 6, 10, 11, 13, 14, 16, 17, 20, 22, 25],
        },
        "select": true,
        "scrollY": "600px",
        "scrollCollapse": true,
        "scrollX": true,
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
        "dom": 'lBfrtip',
        "buttons": [
            {
                extend: 'colvis',
                text: 'Column Visibility',
                titleAttr: 'Column Visibility',
            },
            {
                extend: 'excel',
                text: '<i class="far fa-file-excel fa-lg"></i>',
                titleAttr: 'Export to Excel'
            },
            {
                text: '<i class="fas fa-filter"></i>',
                titleAttr: 'Advanced Filters',
                action: function toggleFilter() {
                    var x = document.getElementsByClassName("dt-searchPanes")[0];
                    if (x.style.display === "none") {
                        x.style.display = "flex";
                    } else {
                        x.style.display = "none";
                    }
                }
            }
        ],
        "overflow-y": scroll,
        "order": [[1, "asc"]],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "render": function (data, type, row, meta) {
                    return '<a href="Items/Details/' + row.cmdbID + '">' + row.cdTag + '</a>';
                }
            },
            {
                "targets": [18, 19, 23, 24],
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
            },
            {
                "targets": [26],
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY hh:mm A')
            }

        ],
        "columns": [
            { "data": "cmdbID" },
            { "data": "cdTag" },
            { "data": "organization" },
            { "data": "hostName" },
            { "data": "location" },
            { "data": "floor" },
            { "data": "room" },
            { "data": "ipAddress" },
            { "data": "subnetMask" },
            { "data": "macAddress" },
            { "data": "manufacturer" },
            { "data": "model" },
            { "data": "serialNumber" },
            { "data": "operatingSystem" },
            { "data": "adUser" },
            { "data": "sunflowerUser" },
            { "data": "status" },
            { "data": "classType" },
            { "data": "acquisitionDate" },
            { "data": "warrantyEndDate" },
            { "data": "custodian" },
            { "data": "comments" },
            { "data": "inventoriedBy" },
            { "data": "inventoryDate" },
            { "data": "lastScan" },
            { "data": "modifiedBy" },
            { "data": "modified" }
        ],
        //"initComplete": function () {

        //}
    });



    // *************** Property Table ****************************

    var property_table = $("#property_table").DataTable({
        "ajax": {
            type: "GET",
            url: "Property/?handler=List",
            serverSide: true,
            dataSrc: "",
            contentType: "application/json",
            dataType: "json",
        },
        "searchPane": {
            columns: [3, 5, 7, 8, 12, 15, 20, 21, 23 ],
        },
        "select": true,
        "scrollY": "600px",
        "scrollCollapse": true,
        "scrollX": true,
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
        "dom": 'lBfrtip',
        "buttons": [
            {
                extend: 'colvis',
                text: 'Column Visibility',
                titleAttr: 'Column Visibility',
            },
            {
                extend: 'excel',
                text: '<i class="far fa-file-excel fa-lg"></i>',
                titleAttr: 'Export to Excel'
            },
            {
                text: '<i class="fas fa-filter"></i>',
                titleAttr: 'Advanced Filters',
                action: function toggleFilter() {
                    var x = document.getElementsByClassName("dt-searchPanes")[0];
                    if (x.style.display === "none") {
                        x.style.display = "flex";
                    } else {
                        x.style.display = "none";
                    }
                }
            }
        ],
        "overflow-y": scroll,
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            { className: "cmdb_blue", "targets": [2, 3, 5, 7, 8, 10, 12, 15, 17, 20, 21, 23, 24] },
            { className: "sunflower_yellow", "targets": [1, 4, 6, 9, 11, 13, 14, 16, 18, 19, 22, 25, 26, 27, 28, 29, 30] },
            {
                "targets": [10, 13, 14, 26, 28, 30],
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
            }
        ],
        "order": [[2, "desc"]],
        "columns": [
            { "data": "sunflowerID" },
            { "data": "cdTag" },
            { "data": "cmdbRecord.cdTag", "defaultContent": "" },
            { "data": "cmdbRecord.adUser", "defaultContent": "" },
            { "data": "currentUser" },
            { "data": "cmdbRecord.room", "defaultContent": "" },
            { "data": "stlv2" },
            { "data": "cmdbRecord.floor", "defaultContent": "" },
            { "data": "cmdbRecord.location", "defaultContent": "" },
            { "data": "stlv1" },
            { "data": "cmdbRecord.inventoryDate", "defaultContent": "" },
            { "data": "stlv3" },
            { "data": "cmdbRecord.inventoriedBy", "defaultContent": "" },
            { "data": "effectiveDate" },
            { "data": "physicalInventoryDate" },
            { "data": "cmdbRecord.status", "defaultContent": "" },
            { "data": "status" },
            { "data": "cmdbRecord.sunflowerUser", "defaultContent": "" },
            { "data": "description" },
            { "data": "modelName" },
            { "data": "cmdbRecord.classType", "defaultContent": "" },
            { "data": "cmdbRecord.organization", "defaultContent": "" },
            { "data": "custArea" },
            { "data": "cmdbRecord.custodian", "defaultContent": "" },
            { "data": "cmdbRecord.hostName", "defaultContent": "" },
            { "data": "resolution" },
            { "data": "resolutionDate" },
            { "data": "finalEvent" },
            { "data": "datetime" },
            { "data": "finalEventUserDefinedFieldLabel01" },
            { "data": "resolutionDate" },
        ]
    });


    $.fn.dataTable.moment('ddd, DD MMM YYYY HH:mm:ss ZZ');
    $.fn.dataTable.moment('M/D/YY h:mm:SS A [EDT]');

    var inventory_table = $("#inventory_table").DataTable({
        "ajax": {
            type: "GET",
            url: "Security/?handler=List",
            serverSide: true,
            dataSrc: "",
            contentType: "application/json",
            dataType: "json",
        },
        "searchPane": {
            columns: [3, 4, 5, 6, 7, 9, 12, 13 ],
        },
        "select": true,
        "scrollY": "600px",
        "scrollCollapse": true,
        "scrollX": true,
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
        "dom": 'lBfrtip',
        "buttons": [
            {
                extend: 'colvis',
                text: 'Column Visibility',
                titleAttr: 'Column Visibility',
            },
            {
                extend: 'excel',
                text: '<i class="far fa-file-excel fa-lg"></i>',
                titleAttr: 'Export to Excel'
            },
            {
                text: '<i class="fas fa-filter"></i>',
                titleAttr: 'Advanced Filters',
                action: function toggleFilter() {
                    var x = document.getElementsByClassName("dt-searchPanes")[0];
                    if (x.style.display === "none") {
                        x.style.display = "flex";
                    } else {
                        x.style.display = "none";
                    }
                }
            }
        ],
        "overflow-y": scroll,
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            { className: "ad_blue", "targets": [8, 9] },
            { className: "ecmo_orange", "targets": [10] },
            { className: "epo_green", "targets": [11] },
            { className: "sccm_red", "targets": [12] },
            { className: "sunflower_yellow", "targets": [13] },
        ],
        "order": [[11, "asc"]],
        "columns": [
            { "data": "cmdbID" },
            { "data": "cdTag" },
            { "data": "hostName" },
            { "data": "location" },
            { "data": "operatingSystem" },
            { "data": "adUser" },
            { "data": "status" },
            { "data": "classType" },
            { "data": "adRecord.description", "defaultContent": "" },
            { "data": "adRecord.accountDisabled", "defaultContent": "" },
            { "data": "ecmoRecord.lastReportTime", "defaultContent": "" },
            { "data": "epoRecord.lastCommunication", "defaultContent": "" },
            { "data": "sccmRecord.operatingSystem", "defaultContent": "" },
            { "data": "sunflowerRecord.status", "defaultContent": "" },
        ],
    });


    var missing_items_table = $("#missing_items_table").DataTable({
        "ajax": {
            type: "GET",
            url: "Discrepancies/?handler=List",
            serverSide: true,
            dataSrc: "",
            contentType: "application/json",
            dataType: "json",
        },
        "searchPane": {
            columns: [2, 4, 5, 6, 10, 11, 13, 14, 16, 17, 20, 22, 25],
        },
        "select": true,
        "scrollY": "600px",
        "scrollCollapse": true,
        "scrollX": true,
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
        "dom": 'lBfrtip',
        "buttons": [
            {
                extend: 'colvis',
                text: 'Column Visibility',
                titleAttr: 'Column Visibility',
            },
            {
                extend: 'excel',
                text: '<i class="far fa-file-excel fa-lg"></i>',
                titleAttr: 'Export to Excel'
            },
            {
                text: '<i class="fas fa-filter"></i>',
                titleAttr: 'Advanced Filters',
                action: function toggleFilter() {
                    var x = document.getElementsByClassName("dt-searchPanes")[0];
                    if (x.style.display === "none") {
                        x.style.display = "flex";
                    } else {
                        x.style.display = "none";
                    }
                }
            }
        ],
        "overflow-y": scroll,
        "order": [[1, "asc"]],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "render": function (data, type, row, meta) {
                    return '<a href="Items/Details/' + row.cmdbID + '">' + row.cdTag + '</a>';
                }
            },
            {
                "targets": [18, 19, 23, 24],
                //"render": function (data, type, row, meta) {
                //    if (row) {
                //        $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
                //    }     
                //}
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
            },
            {
                "targets": [26],
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY hh:mm A')
            }

        ],
        "columns": [
            { "data": "cmdbID" },
            { "data": "cdTag" },
            { "data": "organization" },
            { "data": "hostName" },
            { "data": "location" },
            { "data": "floor" },
            { "data": "room" },
            { "data": "ipAddress" },
            { "data": "subnetMask" },
            { "data": "macAddress" },
            { "data": "manufacturer" },
            { "data": "model" },
            { "data": "serialNumber" },
            { "data": "operatingSystem" },
            { "data": "adUser" },
            { "data": "sunflowerUser" },
            { "data": "status" },
            { "data": "classType" },
            { "data": "acquisitionDate" },
            { "data": "warrantyEndDate" },
            { "data": "custodian" },
            { "data": "comments" },
            { "data": "inventoriedBy" },
            { "data": "inventoryDate" },
            { "data": "lastScan" },
            { "data": "modifiedBy" },
            { "data": "modified" }
        ]
    });



    var my_items_table = $("#my_items_table").DataTable({
        "ajax": {
            type: "GET",
            url: "Hardware/?handler=List",
            serverSide: true,
            dataSrc: "",
            contentType: "application/json",
            dataType: "json",
        },
        //"searchPane": {
        //    columns: [2, 4, 5, 6, 10, 11, 13, 14, 16, 17, 20, 22, 25],
        //},
        "select": true,
        "scrollY": "600px",
        "scrollCollapse": true,
        "scrollX": true,
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
        "dom": 'lBfrtip',
        "buttons": [
            {
                extend: 'colvis',
                text: 'Column Visibility',
                titleAttr: 'Column Visibility',
            },
            {
                extend: 'excel',
                text: '<i class="far fa-file-excel fa-lg"></i>',
                titleAttr: 'Export to Excel'
            },
            //{
            //    text: '<i class="fas fa-filter"></i>',
            //    titleAttr: 'Advanced Filters',
            //    action: function toggleFilter() {
            //        var x = document.getElementsByClassName("dt-searchPanes")[0];
            //        if (x.style.display === "none") {
            //            x.style.display = "flex";
            //        } else {
            //            x.style.display = "none";
            //        }
            //    }
            //}
        ],
        "overflow-y": scroll,
        "order": [[1, "asc"]],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "render": function (data, type, row, meta) {
                    return '<a href="Items/Details/' + row.cmdbID + '">' + row.cdTag + '</a>';
                }
            },
            {
                "targets": [18, 19, 23, 24],
                //"render": function (data, type, row, meta) {
                //    if (row) {
                //        $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
                //    }     
                //}
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
            },
            {
                "targets": [26],
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY hh:mm A')
            }

        ],
        "columns": [
            { "data": "cmdbID" },
            { "data": "cdTag" },
            { "data": "organization" },
            { "data": "hostName" },
            { "data": "location" },
            { "data": "floor" },
            { "data": "room" },
            { "data": "ipAddress" },
            { "data": "subnetMask" },
            { "data": "macAddress" },
            { "data": "manufacturer" },
            { "data": "model" },
            { "data": "serialNumber" },
            { "data": "operatingSystem" },
            { "data": "adUser" },
            { "data": "sunflowerUser" },
            { "data": "status" },
            { "data": "classType" },
            { "data": "acquisitionDate" },
            { "data": "warrantyEndDate" },
            { "data": "custodian" },
            { "data": "comments" },
            { "data": "inventoriedBy" },
            { "data": "inventoryDate" },
            { "data": "lastScan" },
            { "data": "modifiedBy" },
            { "data": "modified" }
        ]
    });




    var custodian_items_table = $("#custodian_items_table").DataTable({
        "ajax": {
            type: "GET",
            url: "Custodian/?handler=List",
            serverSide: true,
            dataSrc: "",
            contentType: "application/json",
            dataType: "json",
        },
        "searchPane": {
            columns: [2, 4, 5, 6, 10, 11, 13, 14, 16, 17, 20, 22, 25],
        },
        "select": true,
        "scrollY": "600px",
        "scrollCollapse": true,
        "scrollX": true,
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
        "dom": 'lBfrtip',
        "buttons": [
            {
                extend: 'colvis',
                text: 'Column Visibility',
                titleAttr: 'Column Visibility',
            },
            {
                extend: 'excel',
                text: '<i class="far fa-file-excel fa-lg"></i>',
                titleAttr: 'Export to Excel'
            },
            {
                text: '<i class="fas fa-filter"></i>',
                titleAttr: 'Advanced Filters',
                action: function toggleFilter() {
                    var x = document.getElementsByClassName("dt-searchPanes")[0];
                    if (x.style.display === "none") {
                        x.style.display = "flex";
                    } else {
                        x.style.display = "none";
                    }
                }
            }
        ],
        "overflow-y": scroll,
        "order": [[1, "asc"]],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "render": function (data, type, row, meta) {
                    return '<a href="Items/Details/' + row.cmdbID + '">' + row.cdTag + '</a>';
                }
            },
            {
                "targets": [18, 19, 23, 24],
                //"render": function (data, type, row, meta) {
                //    if (row) {
                //        $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
                //    }     
                //}
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
            },
            {
                "targets": [26],
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY hh:mm A')
            }

        ],
        "columns": [
            { "data": "cmdbID" },
            { "data": "cdTag" },
            { "data": "organization" },
            { "data": "hostName" },
            { "data": "location" },
            { "data": "floor" },
            { "data": "room" },
            { "data": "ipAddress" },
            { "data": "subnetMask" },
            { "data": "macAddress" },
            { "data": "manufacturer" },
            { "data": "model" },
            { "data": "serialNumber" },
            { "data": "operatingSystem" },
            { "data": "adUser" },
            { "data": "sunflowerUser" },
            { "data": "status" },
            { "data": "classType" },
            { "data": "acquisitionDate" },
            { "data": "warrantyEndDate" },
            { "data": "custodian" },
            { "data": "comments" },
            { "data": "inventoriedBy" },
            { "data": "inventoryDate" },
            { "data": "lastScan" },
            { "data": "modifiedBy" },
            { "data": "modified" }
        ]
    });



    var custodian_missing_items_table = $("#custodian_missing_items_table").DataTable({
        "ajax": {
            type: "GET",
            url: "Missing/?handler=List",
            serverSide: true,
            dataSrc: "",
            contentType: "application/json",
            dataType: "json",
        },
        "searchPane": {
            columns: [2, 4, 5, 6, 10, 11, 13, 14, 16, 17, 20, 22, 25],
        },
        "select": true,
        "scrollY": "600px",
        "scrollCollapse": true,
        "scrollX": true,
        "lengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
        "dom": 'lBfrtip',
        "buttons": [
            {
                extend: 'colvis',
                text: 'Column Visibility',
                titleAttr: 'Column Visibility',
            },
            {
                extend: 'excel',
                text: '<i class="far fa-file-excel fa-lg"></i>',
                titleAttr: 'Export to Excel'
            },
            {
                text: '<i class="fas fa-filter"></i>',
                titleAttr: 'Advanced Filters',
                action: function toggleFilter() {
                    var x = document.getElementsByClassName("dt-searchPanes")[0];
                    if (x.style.display === "none") {
                        x.style.display = "flex";
                    } else {
                        x.style.display = "none";
                    }
                }
            }
        ],
        "overflow-y": scroll,
        "order": [[1, "asc"]],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "render": function (data, type, row, meta) {
                    return '<a href="Items/Details/' + row.cmdbID + '">' + row.cdTag + '</a>';
                }
            },
            {
                "targets": [18, 19, 23, 24],
                //"render": function (data, type, row, meta) {
                //    if (row) {
                //        $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
                //    }     
                //}
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
            },
            {
                "targets": [26],
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY hh:mm A')
            }

        ],
        "columns": [
            { "data": "cmdbID" },
            { "data": "cdTag" },
            { "data": "organization" },
            { "data": "hostName" },
            { "data": "location" },
            { "data": "floor" },
            { "data": "room" },
            { "data": "ipAddress" },
            { "data": "subnetMask" },
            { "data": "macAddress" },
            { "data": "manufacturer" },
            { "data": "model" },
            { "data": "serialNumber" },
            { "data": "operatingSystem" },
            { "data": "adUser" },
            { "data": "sunflowerUser" },
            { "data": "status" },
            { "data": "classType" },
            { "data": "acquisitionDate" },
            { "data": "warrantyEndDate" },
            { "data": "custodian" },
            { "data": "comments" },
            { "data": "inventoriedBy" },
            { "data": "inventoryDate" },
            { "data": "lastScan" },
            { "data": "modifiedBy" },
            { "data": "modified" }
        ]
    });



});


