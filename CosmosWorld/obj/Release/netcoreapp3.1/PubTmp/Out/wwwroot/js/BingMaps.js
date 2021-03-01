var map;

function loadBasicMapScenario() {
    map = new Microsoft.Maps.Map(document.getElementById('Map'), {
    });
}

function loadMapScenario(Long, Lat) {
    map = new Microsoft.Maps.Map(document.getElementById('Map'), {
        center: new Microsoft.Maps.Location(Long, Lat),
    });

    var pushpin = new Microsoft.Maps.Pushpin(map.getCenter(), null);
    map.entities.push(pushpin);
}
