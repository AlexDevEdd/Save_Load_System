using System;
using Cysharp.Threading.Tasks;

namespace SaveLoad.DataStorages
{
    internal sealed class CloudDataStorage : IDataStorage
    {
        private bool _isInProgressNow;
        
        public UniTask WriteAsync(string key, string data)
        {
            return UniTask.CompletedTask;
            // if(_isInProgressNow) return;
            //
            // try
            // {
            //     _isInProgressNow = true;
            //     
            //     var dict = new Dictionary<string, object> { { key, data } };
            //     await CloudSaveService.Instance.Data.Player.SaveAsync(dict);
            //
            //     _isInProgressNow = false;
            // }
            // catch (Exception e)
            // {
            //     _isInProgressNow = false;
            //     throw new ArgumentException($"Something went wrong : {e}");
            // }
        }

        public UniTask<string> ReadAsync<TData>(string key)
        {
            return UniTask.FromResult(key);
            // try
            // {
            //     var playerData =
            //         await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string>() { key });
            //
            //     if (playerData.TryGetValue(key, out var data))
            //     {
            //         return data;
            //     }
            // }
            // catch (Exception e)
            // {
            //     Log.ColorLogDebugOnly(e.ToString(), ColorType.Red, LogStyle.Error);
            //     return default;
            // }
            //
            // return default;
        }

        [Obsolete("Obsolete")]
        public void Remove(string key)
        {
            //await CloudSaveService.Instance.Data.Player.DeleteAsync(key);
        }
    }
}