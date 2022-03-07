function generateSlug(v) {
    $('#Slug').val(v.replace(new RegExp(" ", "\g"), "-").toLowerCase());
}


