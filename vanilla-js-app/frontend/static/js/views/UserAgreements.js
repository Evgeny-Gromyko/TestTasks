export default function getUserAgreements(paragraphs, onAccept) {
    const userAgreement = document.createElement("div");
    userAgreement.innerHTML = `<h1>Terms of Use</h1>`;
    userAgreement.className = "user-agreement"

    const termsContent = document.createElement("div");
    paragraphs?.forEach((paragraph) => {
        const paragraphElement = document.createElement("div");
        paragraphElement.innerHTML = `<h2>${paragraph.title}</h2><p>${paragraph.content}</p>`;
        termsContent.appendChild(paragraphElement);
    });
    userAgreement.appendChild(termsContent);

    const acceptButton = document.createElement("button");
    acceptButton.textContent = "Accept";
    acceptButton.addEventListener("click", onAccept);

    const buttonContainer = document.createElement("div");
    buttonContainer.className = "agreement-actions"
    buttonContainer.appendChild(acceptButton);
    userAgreement.appendChild(acceptButton);

    return userAgreement;
}
