
window.saveLandlordList = (key, data) => {
    localStorage.setItem(key, JSON.stringify(data));
};

window.loadLandlordList = (key) => {
    const data = localStorage.getItem(key);
    return data ? JSON.parse(data) : [];
};
