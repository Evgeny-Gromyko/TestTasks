import handleDownload from "./handleDownload.js";
import getGalery from "./views/Galery.js";
import getUserAgreements from "./views/UserAgreements.js";

let fetchedData = null;
let termsAccepted = false;

const navigateTo = url => {
    history.pushState(null, null, url);
    router();
};

const acceptTermsOfUse = () => { 
    termsAccepted = true;
    navigateTo("/main");
}

const getUserAgreementsView = () => getUserAgreements(fetchedData?.terms_of_use?.paragraphs, acceptTermsOfUse)
const getGaleryView = () => termsAccepted ? 
    getGalery(fetchedData?.images, handleDownload) 
    :
    getUserAgreementsView()

const router = () => {
    const routes = [
        { path: "/", view: getUserAgreementsView },
        { path: "/user-agreement", view: getUserAgreementsView },
        { path: "/main", view: getGaleryView }
    ];

    let route = routes.find(route => location.pathname === route.path);

    if (!route) {
        route = routes[0];
    }

    var appElement = document.querySelector("#app")
    appElement.innerHTML = "";
    appElement.appendChild(route.view());
};

window.addEventListener("popstate", router);

document.addEventListener("DOMContentLoaded", () => {
    document.body.addEventListener("click", e => {
        if (e.target.matches("[data-link]")) {
            e.preventDefault();
            navigateTo(e.target.href);
        }
    });

    try {
        const host = "http://188.166.203.164"
        fetch(host + "/static/test.json")
            .then(response => response.json())
            .then(data => ({...data, images: data.images.map(image => host + image.image_url)}))
            .then(data => {
                fetchedData = data;
            })
            .then(router);
    }
    catch {
        console.error("Error fetching data:", error);
        router();
    }
});
