fetch("http://0.0.0.0:5050/api/registrations")
    .then(res => res.json())
    .then(data => {
    document.getElementById("lista").innerHTML = data[0];
});