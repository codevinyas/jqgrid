function gridRefresh() {
    var startDateInput = $("#startDate").val();
    var endDateInput = $("#endDate").val();
    if (startDateInput === "") {
        alert("Please enter a valid start date");
        return;
    }
    if (endDateInput === "") {
        alert("Please enter a valid end date");
        return;
    }

    if (startDateInput > endDateInput) {
        alert("Start date should be less than end date");
        return;
    }
    $("#jqGrid").jqGrid('setGridParam', { postData: { startDate: startDateInput, endDate: endDateInput } }).trigger("reloadGrid");
}