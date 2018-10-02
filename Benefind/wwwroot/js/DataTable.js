//// Add DataTable() to benefits table
//$(document).ready(function () {
//    $('#tb-benefits').DataTable({
//    });
//    $('.dataTables_length').addClass('bs-select');
//});

////All benefits table
//$(document).ready(function () {
//    $('#table-all-benefits').DataTable({
//    });
//    $('.dataTables_length').addClass('bs-select');
//});
var filterTable;
var sourceTable;
$(document).ready(function () {
    //filterTable = $('#tb-benefits').DataTable();
    sourceTable = $('#table-all-benefits').DataTable({
        language: {
            search: "_INPUT_",
            searchPlaceholder: "    Enter keyword"
        }
    });
    //filterTable.draw();
    sourceTable.draw();
    $('.dataTables_length').addClass('browser-default');
});

//filter result datatable initialization
$(document).ready(function () {

    filterTable = $('#tb-benefits').DataTable({
        searching: true,
        
        language: {
            search: "_INPUT_",
            searchPlaceholder: "    Enter keyword"
        }  ,
        "ajax": {
            "url": "/Ndis201819/FilterResultAll",
            "type": "GET",
            "datatype": "json",
            "dataSrc": ''
        },
        "columns": [
            { "data": "registrationGroup" },
            { "data": "supportItemNumber" },
            { "data": "supportItem" },
            { "data": "supportItemDescription" },
            { "data": "priceLimit" },
            { "data": "quote" },
            { "data": "unitOfMeasure" }, 
            { "data": "priceControl" },
            { "data": "supportCategories" },
            { "data": "supportCategoryNumber" }

        ],
        "columnDefs": [
            {
                "targets": [1,5, 7, 8, 9],
                "visible": false,
                'searchable': true,
                'orderable': false
            },
            {
                "targets": [3],
                'orderable': false
            }
        ]

    });
});

//ajax call for filtered results when "show result" is clicked
$("#nav-showresult-tab").on('click', function () {

    var hostString = window.location.protocol + "//" + window.location.host + "/";
    var filteredResult = getQuizValue();
    console.log(JSON.stringify(filteredResult));

    $.ajax({
        type: 'POST',
        //url: "Ndis201819/Filter",
        url: "/Ndis201819/Filter/",
        data: JSON.stringify(filteredResult),
        contentType: "application/json; charset=utf-8",
        dataType: "json",   

        success: function (response) {
            console.log('Data received: ');
            console.log(response);
            filterTable
                .clear().draw();
            filterTable
                .rows.add(response)
                .draw();
        },
        failure: function () {
            alert("json response error");
        }

    });
});


//$('form').submit(function (event) {

//    /* stop form from submitting normally */
//    event.preventDefault();
//    console.log("enter function");

//    var contents = GetJsonData();

//    //test
//    console.log("enter function");
//    console.log(contents);

//    $.ajax({
//        type: 'post',
//        url: "/Ndis201819/Filter",
//        data: JSON.stringify(contents),
//        contentType: "application/json; charset=utf - 8",
//        success: function (response) {
//            console.log('Data received: ');
//            console.log(response.responseText);

//            $("form").html(response);
//        },
//        failure: function () {
//            alert("json response error");
//        }

//    });
//});


function GetJsonData() {
    var json = {
        "Support Categories": $("#inputState").val()
    };
    return json;
}

/* filter function */

//var filterTable = $('#tb-benefits').DataTable();
//var sourceTable = $('#table-all-benefits').DataTable();

//$('#transportation input[name=transportation]').change(function () {
//    alert("filtertable: " + filterTable.data().rows().count());

//    if (this.value == 'yes') {
        //var testFilteredData = sourceTable
        //    .column(0)
        //    .data()
        //    .filter(function (value, index) {
        //        return value > 20 ? true : false;
        //    });

//        sourceTable.search("Transitional Support|Assistance with daily life (includes Supported Independent Living)").draw();   

//        alert("testfilter : " + testFilteredData.data().rows().count());

//        filterTable.clear();
//        filterTable.push(testFilteredData);
//        alert("after clear and push: " + filterTable.data().rows().count());
//        console.log(JSON.stringify(filterTable.rows().data()));
//        filterTable.draw();
//    }
//    else if (this.value == 'no') {
//        alert('no');
//    }
//});

/* test getQuizValue() */
//$('.Single-Quize-Container input').change(function () {
//    console.log(getQuizValue());
//    var a = getQuizValue();
//    console.log(JSON.stringify(a));
//});

/* get all quiz value */
function getQuizValue() {
    var quizResult = [];
 
    $(".Single-Quize-Container").each(function () {
        var QuizName = $(this).find('input').prop("name");
        
        //var quizName = $(this).find('input').serialize();
        var Option = $("input:checked", $(this)).val();
        //var pair = {};
        //if (option !== undefined) {
            
        //    pair =  String(quizName)  + ':' + String(option) ;
        //}
        //else {
        //    pair =  String(quizName) + ':' + 'empty' ;
        //}

        if ($(this).prop("id") === "quiz-region-dropdown") { //for get value of region dropdown
            QuizName = "region";
            Option = $("select").val();
        }

        //quizResult.push(

        //    String(quizName), ":", String(option)
            
        //);

        if (Option !== undefined) {
            quizResult.push(
                {
                    QuizName, Option
                }
            );
            }
         else {
             quizResult.push({
                 QuizName,
                 Option: "empty"
             });
                }
        
    });
    return quizResult;
}