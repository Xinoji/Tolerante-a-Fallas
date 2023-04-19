package com.vorozco.controller;

import com.vorozco.model.Tag;
import org.eclipse.microprofile.faulttolerance.Bulkhead;
import org.eclipse.microprofile.faulttolerance.CircuitBreaker;
import org.eclipse.microprofile.faulttolerance.Fallback;
import org.eclipse.microprofile.faulttolerance.Retry;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.logging.Logger;

@Path("/Test")
@Produces(MediaType.APPLICATION_JSON)
public class TestController {

    List<Tag> tagList = new ArrayList<>();
    Logger LOGGER = Logger.getLogger("Demologger");

    @GET
    @Retry(maxRetries = 4)
    @CircuitBreaker(failureRatio = 0.1, delay = 15000L)
    @Bulkhead(value = 0)
    @Fallback(fallbackMethod = "getTagFallbackList")
    public List<Tag> getTagList(){
        LOGGER.info("Ejecutando");
        doWait();
        return this.tagList;
    }

    public List<Tag> getTagFallbackList(){
        var Tag = new Tag(-1L, -1L, "Red");
        return List.of(Tag);
    }

    public void doWait(){
        var random = new Random();
        try {
            LOGGER.warning("sleep");
            Thread.sleep((random.nextInt(10) + 4) * 1000L);
        }catch (Exception ex){

        }
    }

    public void doFail(){
        var random = new Random();
        if(random.nextBoolean()){
            LOGGER.warning("falla");
            throw  new RuntimeException("Implementacion falle");
        }
    }

}
