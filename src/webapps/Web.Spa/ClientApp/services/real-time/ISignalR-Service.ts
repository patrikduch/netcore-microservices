/**
 * @interface ISignalRService Interface contract of SignalRService.
 */
export default interface ISignalRService {
    notify();
    startSuccess(notify: any );
    startFail();
}