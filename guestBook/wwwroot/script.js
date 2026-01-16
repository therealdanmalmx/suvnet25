fetch("/api/guests")
    .then(res => {return res.json()})
    .then(data => {
        document.getElementById("guest-list").innerHTML = data.map(guest => `
            <div style="border: 1px solid red; width: 200px; padding: 10px; margin-bottom: 3px;">
                <p style="font-weight: bold; font-size: 1.5rem">${guest.name}</p>
                <p style="color: green">${guest.message}</p>
            </div>
        `).join('')
    })