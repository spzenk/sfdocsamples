function GetText(txtName) {

    tinyMCE.triggerSave(false, true);
    txtArea = document.getElementById(txtName);
    alert('txtBody.VALUE : ' + txtArea.value)
    return txtArea.value;

}   