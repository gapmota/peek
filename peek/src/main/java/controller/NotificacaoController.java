package controller;

import aplicacao.App;
import com.github.seratch.jslack.Slack;
import com.github.seratch.jslack.api.webhook.Payload;
import com.github.seratch.jslack.api.webhook.WebhookResponse;
import model.Processador;
import model.MemoriaRam;
import oshi.SystemInfo;
import controller.ComputadorController;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import model.Computador;

public class NotificacaoController {

    Computador c = new Computador();

    public void enviarSlack(String texto) {
        DateFormat df = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
        Date date = new Date();

        String url = "https://hooks.slack.com/services/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";

        Payload payload = Payload.builder()
                .channel("#avisos-peek")
                .username("Integrador")
                .iconEmoji(":smile_cat:")
                .text(texto + df.format(date))
                .build();

        Slack slack = Slack.getInstance();
        try {
            WebhookResponse response = slack.send(url, payload);
        } catch (IOException ex) {
            Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public boolean iniciarSistema() {

        new NotificacaoController().enviarSlack("Sistema iniciado ");
        return true;
    }

    public void usoProcessador() {
        new NotificacaoController().enviarSlack("Alto consumo do processador ");
    }

    public void usoMemoriaRAM() {
        new NotificacaoController().enviarSlack("Alto consumo de RAM ");
    }
    
    public void hdCheio() {
        new NotificacaoController().enviarSlack("HD quase cheio ");
    }

    public void novaMaquina() {
        new NotificacaoController().enviarSlack("Nova máquina cadastrada ");
    }
}
