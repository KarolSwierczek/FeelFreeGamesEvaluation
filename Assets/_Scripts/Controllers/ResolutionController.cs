using System.Reflection;
using FeelFreeGames.Evaluation.Data;
using FeelFreeGames.Evaluation.Input;
using TMPro;
using UnityEditor;
using UnityEngine;
using Zenject;
using MathUtils = FeelFreeGames.Evaluation.Utils.MathUtils;

namespace FeelFreeGames.Evaluation.Controllers
{
    public class ResolutionController : MonoBehaviour
    {
        [SerializeField] private ResolutionSettings _Settings;
        [SerializeField] private TextMeshProUGUI _ResolutionInfo;

        private IGameInput _gameInput;
        private int _currentResolutionIndex;

        [Inject]
        private void ResolveBindings(IGameInput gameInput)
        {
            _gameInput = gameInput;
        }

        private void Awake()
        {
            SetResolution(_currentResolutionIndex);
            
            _gameInput.NextResolution += OnNextResolutionSelected;
            _gameInput.PreviousResolution += OnPreviousResolutionSelected;
            
            _gameInput.Enable();
        }

        private void OnDestroy()
        {
            _gameInput.Disable();
            
            _gameInput.NextResolution -= OnNextResolutionSelected;
            _gameInput.PreviousResolution -= OnPreviousResolutionSelected;
        }

        private void OnNextResolutionSelected()
        {
            _currentResolutionIndex = MathUtils.Mod(_currentResolutionIndex + 1, _Settings.Count);
            SetResolution(_currentResolutionIndex);
        }
        
        private void OnPreviousResolutionSelected()
        {
            _currentResolutionIndex = MathUtils.Mod(_currentResolutionIndex - 1, _Settings.Count);
            SetResolution(_currentResolutionIndex);
        }
        
        private void SetResolution(int index)
        {
            var resolutionIndex = _Settings.EditorIndices[index];
            var resolution = _Settings.Resolutions[index];
            
            _ResolutionInfo.SetText($"current resolution: {resolution.x}x{resolution.y}");
#if UNITY_EDITOR
            var gvWndType = typeof(Editor).Assembly.GetType("UnityEditor.GameView");
            var gvWnd = EditorWindow.GetWindow(gvWndType);
            var sizeSelectionCallback = gvWndType.GetMethod("SizeSelectionCallback",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            
            sizeSelectionCallback?.Invoke(gvWnd, new object[] {resolutionIndex,null});
#else
            Screen.SetResolution(resolution.x, resolution.y, false);
#endif
        }
    }
}