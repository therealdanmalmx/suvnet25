fetch("http://0.0.0.0:5050/api/registrations")
    .then(res => {return res.json()})
    .then(data => {
        document.getElementById("lista").innerHTML = data.map(e => `
             <div>
                <p>${e.name}: ${e.email}</p>
            </div>`
        ).join('');
    });