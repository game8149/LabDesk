
var SolicitudDinero = function (pk, numero, fecha, idArea, idMotivo, idPersona, idProveedor, idCtaProveedor, idMoneda, state) {
    var _pk = pk;
    var _numero = numero;
    var _fecha = fecha;
    var _idArea = idArea;
    var _idMotivo = idMotivo;
    var _idPerson = idPersona;
    var _tipoDocumento = null;
    var _nombrePersona = null;
    var _cuentaBancaria = null;
    var _nombreBanco = null;
    var _tipoCuentaBancaria = null;

    var _idProveedor = idProveedor;
    var _idCtaBancariaProveedor = idCtaProveedor;
    var _idMoneda = idMoneda;

    var _state = state;
    var _self = this;

    var _detail = [];

    /**
     * Instancia un Personal en base a un objeto Json con propiedades del Personal
     * @param dataJson Objeto Json que será usado para instanciar el Personal.
     */

    var build = function (dataJson) {
        _selft = SolicitudDinero(
            dataJson.Id,
            dataJson.Nombres,
            dataJson.ApellidoPaterno,
            dataJson.ApellidoMaterno,
            dataJson.IdTipoDocumento,
            dataJson.NumDocumento,
            dataJson.IdCentroCosto,
            dataJson.IdPlanilla,
            dataJson.Tipo
        );
    }

    var buildJson = function () {
        return {
            Id,
            Nombres,
            ApellidoPaterno,
            apellidoMaterno,
            IdTipoDocumento,
            NumDocumento,
            IdCentroCosto,
            IdPlanilla,
            Tipo
        };
    }

    return {
        PK: _pk,
        Numero: _numero,
        Fecha: _fecha,
        IdArea: _idArea,
        TipoDocumento: _tipoDocumento,
        IdMotivo: _idMotivo,
        IdPersona: _idPerson,
        NisiraNombrePersona: _nombrePersona,
        NisiraCuentaBancaria: _cuentaBancaria,
        NisiraBanco: _nombreBanco,
        NisiraTipoCuentaBancaria: _tipoCuentaBancaria,

        IdProveedor: _idProveedor,
        IdCtaBancariaProveedor: _idCtaBancariaProveedor,
        IdMoneda: _idMoneda,

        Detalle: _detail,
        Estado: _state,
        LastModified: _lastModified,

        Build: build,
        Me: _self
    };


}

var SolicitudDineroDetalle = function (pk, index, tipo, idMotivo, importe, anotacion, idTipoAbono, stateCheck, tiempo) {
    var _pk = pk;
    var _index = index;
    var _idMotivo = idMotivo;
    var _importe = importe;
    var _anotacion = anotacion;
    var _tipo = tipo;
    var _idTipoAbono = idTipoAbono;
    var _stateCheck = stateCheck;
    var _tiempo = tiempo;

    var buildJson = function () {
        return {
            Id,
            Nombres,
            ApellidoPaterno,
            apellidoMaterno,
            IdTipoDocumento,
            NumDocumento,
            IdCentroCosto,
            IdPlanilla,
            Tipo
        };
    }

    return {
        PK: _pk,
        Indice: _index,
        IdMotivo: _idMotivo,
        TipoAbono: _idTipoAbono,
        Importe: _importe,
        Anotacion: _anotacion,
        Estado: _stateCheck,
        Fecha: _Tiempo,
        Tipo: _tipo,
        Build: build
    };
}