import React, { useEffect, useState } from 'react';
import SignalRService from '@Services/real-time/SignalR-Service';

import './Website-Statistics-Container.scss';
import { ClipLoader } from 'react-spinners';


const WebStatisticsContainer: React.FC = () => {
    let [loading, setLoading] = useState(true);
    let [color] = useState("#000");

    const [count, setCount] = useState(0);

    useEffect(() => {
        const connection = new SignalRService('https://signalr-sample-service.azurewebsites.net/hubs/view', 'notifyWatching');
        connection.getSignalInstance().start().then(connection.startSuccess, connection.startFail);

        // on view update message from client
        connection.getSignalInstance().on("viewCountUpdate", (value: number) => {
            setCount(value);
            setLoading(false);
        });    
    }, []);

    return (
        <div className='col-sm-4 website-statistics-container'>
             <h3 className='website-statistics-container__heading'>Website statistics</h3>
             <p>Connected users: { loading ? <ClipLoader color={color} loading={loading} size={15} /> : count }</p>
        </div>
    );
};

export default WebStatisticsContainer;


