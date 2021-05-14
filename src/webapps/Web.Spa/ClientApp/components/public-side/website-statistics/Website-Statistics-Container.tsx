import React, { useEffect, useState } from 'react';
import SignalRService from '@Services/real-time/SignalR-Service';
import './Website-Statistics-Container.scss';
import { ClipLoader } from 'react-spinners';

const WebStatisticsContainer: React.FC = () => {
    let [loading, setLoading] = useState(true);
    let [color] = useState("#000");
    const [count, setCount] = useState("");

    useEffect(() => {
        const connection = new SignalRService('http://51.144.186.129/hubs/test', 'SendNewPosition');
        connection.getSignalInstance().start().then(connection.startSuccess, connection.startFail).catch((err => {
            setTimeout(() => {
                connection.getSignalInstance().start();
            }, 5000);
        }));
      
        // on view update message from client
        connection.getSignalInstance().on("ReceivedNewPosition", (value: {uid: string})  => {
            debugger;
            setCount(value.uid);
            setLoading(false);
        });    
        
        connection.getSignalInstance().onclose(() => {

            setTimeout(() => {
                connection.getSignalInstance().start();
            }, 1000);

            // on view update message from client
            connection.getSignalInstance().on("ReceivedNewPosition", (value: {uid: string}) => {
                debugger;
                setCount(value.uid);
                setLoading(false);
            });   

        });
    });

    return (
        <div className='col-sm-4 website-statistics-container'>
             <h3 className='website-statistics-container__heading'>Website statistics</h3>
             <p>Connected users: { loading ? <ClipLoader color={color} loading={loading} size={15} /> : count }</p>
        </div>
    );
};

export default WebStatisticsContainer;


