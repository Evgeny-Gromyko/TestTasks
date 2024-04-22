const host = 'http://188.166.203.164';

export const GetAPIData = () => {
    return fetch(host + '/static/test.json')
        .then((response) => response.json())
        .then(data => ({...data, images: data.images.map(image => host + image.image_url)}));
}
