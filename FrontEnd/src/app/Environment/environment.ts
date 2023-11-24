export const environment = {
    production: false,
    apiUrl: 'http://localhost:25571/',
  };

  export const environment1 = {
    production: false,
    wsEndpoint: 'ws://localhost:8081/',
    RTCPeerConfiguration: {
      iceServers: [
        {
          urls: 'stun:stun1.l.google.com:19302'
        }
      ]
    }
  };