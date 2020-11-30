async function getData() {
    //fetch api default method is GET  
    const uri = "https://localhost:44349/values"
    debugger
    const response = await fetch(uri)
    const data = await response.json()
    data.forEach(value => {
        debugger
        document.getElementById('destinations').innerHTML += '<li id="' + value.id + '">' + value.id + ': ' + value.cityName + ' - ' + value.airport + '</li>';
    })
    /*
    fetch(uri)
        .then(response => {            
            return response.json()
        })
        .then(function (data) {            
            data.forEach(value => {
                debugger
                document.getElementById('destinations').innerHTML += '<li id="' + value.id + '">' + value.id + ': ' + value.cityName + ' - ' + value.airport + '</li>';
            });
        })
        */
    //...
}