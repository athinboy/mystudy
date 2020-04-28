package org.fgq.study.springcloud;

import org.springframework.cloud.client.ServiceInstance;
import org.springframework.cloud.client.discovery.DiscoveryClient;

import java.util.List;

/**
 * @author fenggqc
 * @create 2019-05-22 16:03
 **/
public class DiscoveryClientImpl implements DiscoveryClient {

    //region Getter And Setter
    // endregion

    /**
     * A human readable description of the implementation, used in HealthIndicator
     *
     * @return
     */
    @Override
    public String description() {
        return null;
    }

    /**
     * @return ServiceInstance with information used to register the local service
     */
    @Override
    public ServiceInstance getLocalServiceInstance() {
        return null;
    }

    /**
     * Get all ServiceInstance's associated with a particular serviceId
     *
     * @param serviceId the serviceId to query
     * @return a List of ServiceInstance
     */
    @Override
    public List<ServiceInstance> getInstances(String serviceId) {
        return null;
    }

    /**
     * @return all known service id's
     */
    @Override
    public List<String> getServices() {
        return null;
    }
}
