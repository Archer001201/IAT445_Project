using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class TimelineEventHandler : MonoBehaviour
{
    public PlayableDirector playableDirector; // 绑定你的 Timeline PlayableDirector
    public UnityEvent onTimelineEnd;         // 定义 UnityEvent

    private bool isTimelinePlaying = false;  // 标志是否正在播放 Timeline

    void Start()
    {
        if (playableDirector == null)
        {
            Debug.LogError("PlayableDirector 未绑定！");
            return;
        }

        // 注册 PlayableDirector 的状态更改事件
        playableDirector.stopped += OnTimelineStopped;
    }

    void Update()
    {
        // 检测 Timeline 的播放状态（播放中且未完成）
        if (playableDirector.state == PlayState.Playing && !isTimelinePlaying)
        {
            isTimelinePlaying = true;
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // 当 Timeline 停止时（播放完成或手动停止）
        if (isTimelinePlaying)
        {
            isTimelinePlaying = false;
            onTimelineEnd?.Invoke(); // 触发 UnityEvent
        }
    }

    void OnDestroy()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnTimelineStopped; // 取消事件注册
        }
    }
}