export default function handleDownload(fileUrl, filename) {
    fetch(fileUrl)
        .then(response => {
            response.arrayBuffer().then(function (buffer) {
                const url = window.URL.createObjectURL(new Blob([buffer]));
                const link = document.createElement("a");
                link.href = url;
                link.setAttribute("download", filename);
                document.body.appendChild(link);
                link.click();
            });
        })
        .catch(err => {
            console.log(err);
        });
};
