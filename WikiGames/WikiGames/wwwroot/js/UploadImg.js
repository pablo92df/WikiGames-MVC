function UploadImages() {
    let inputImg = document.getElementById('file');
    inputImg.addEventListener("change", function () {
        var image = document.getElementById('output');
        image.src = URL.createObjectURL(event.target.files[0]);
    });
}