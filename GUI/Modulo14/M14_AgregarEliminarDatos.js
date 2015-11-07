function agregarDat() {
    agregarObjeto(document.agregar_planilla.dat_primary, document.agregar_planilla.dat_secondary);
}

function agregarObjeto(m1, m2) {
    for (var i = 0; i < m1.length ; i++)
        if (m1.options[i].selected === true)
            m2.options[m2.length] = new Option(m1.options[i].text);

    for (i = (m1.length - 1) ; i >= 0; i--)
        if (m1.options[i].selected === true)
            m1.options[i] = null;
}

function eliminarDat() {
    eliminarObjeto(document.agregar_planilla.dat_primary, document.agregar_planilla.dat_secondary);
}


function eliminarObjeto(m1, m2) {
    for (var i = 0; i < m2.length ; i++)
        if (m2.options[i].selected === true)
            m1.options[m1.length] = new Option(m2.options[i].text);

    for (var i = (m2.length - 1) ; i >= 0; i--)
        if (m2.options[i].selected === true)
            m2.options[i] = null;
}