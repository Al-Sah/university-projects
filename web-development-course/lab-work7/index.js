
function renderForm(){
    let content = document.getElementById("dynamic-content");
    content.innerHTML = form
}

function getClients(){
    alert("Get clients ")
}

let form=`
<form action="index.php" method="get" class="shadow-sm p-3 mb-5 bg-body rounded">
    <div class="form-check ">
        <input class="form-check-input" type="radio" name="clients-filter" id="filter1" value="cf1">
        <label class="form-check-label" for="filter1"> Show all clients </label>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="radio" name="clients-filter" id="filter2" value="cf2">
        <label class="form-check-label" for="filter2"> Show with money </label>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="radio" name="clients-filter" id="filter3" value="cf3">
        <label class="form-check-label" for="filter3"> Show without money </label>
    </div>
    <div class="p-2 mt-1">
        <button class="btn btn-success" onclick="getClients()">Apply filter</button>
    </div>
</form>
`