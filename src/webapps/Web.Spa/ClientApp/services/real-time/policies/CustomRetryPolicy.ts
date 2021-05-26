class CustomRetryPolicy implements signalR.IRetryPolicy {

    /**
     * @function nextRetryDelayInMilliseconds Retry policy for establishment connection with SignalR.
     * @param retryCtx Context of retry attempts.
     * @returns Number of seconds.
     */
    nextRetryDelayInMilliseconds(retryCtx: signalR.RetryContext): number {
        console.log(`Retry :: ${retryCtx.retryReason}`);
        if (retryCtx.previousRetryCount === 10) return null; // stawp
    
        var nextRetry = retryCtx.previousRetryCount * 1000 || 1000;
        console.log(`Retry in ${nextRetry} miliseconds`);

        return nextRetry;
    }
}

export default CustomRetryPolicy;