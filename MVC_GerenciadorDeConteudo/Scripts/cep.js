jQuery(function ($){
    $("input[name='cep']").change(function (){
        var cep_code = $(this).val();
        if (cep+code.length <= 0) return;
        $.get("https://viacep.com.br/ws/01001000/json", {code: cep_code}, function (result){
            if (result.status !== 1){
                alert(result.message || "Cep não encontrado")
                return;
            }
            $("input[name='cep']").val(result.code);
            $("input[name='bairro']").val(result.district);
            $("input[name='estado']").val(result.state);
            $("input[name='cidade']").val(result.city);
            $("input[name='endereco']").val(result.address);
        })
    })
})