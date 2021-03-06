﻿using System;
using System.Collections;
using Dynamo.Models;
using Dynamo.Interfaces;
using Autodesk.DesignScript.Interfaces;

namespace Dynamo.Interfaces
{
    public interface IVisualizationManager : IDisposable
    {
        /// <summary>
        /// Is another context available for drawing?
        /// This property can be queried indirectly by the view to enable or disable
        /// UI functionality based on whether an alternate drawing context is available.
        /// </summary>
        bool AlternateDrawingContextAvailable { get; set; }

        /// <summary>
        /// Should we draw to the alternate context if it is available?
        /// </summary>
        bool DrawToAlternateContext { get; set; }

        /// <summary>
        /// Can be used to expose a name of the alternate context for use in the UI.
        /// </summary>
        string AlternateContextName { get; set; }

        /// <summary>
        /// An event triggered on the completion of visualization update.
        /// </summary>
        event Action RenderComplete;

        /// <summary>
        /// Display a label for one or several render packages 
        /// based on the paths of those render packages.
        /// </summary>
        /// <param name="path"></param>
        void TagRenderPackageForPath(string path);

        /// <summary>
        /// An event triggered when there are results to visualize
        /// </summary>
        event Action<VisualizationEventArgs> ResultsReadyToVisualize;

        /// <summary>
        /// Request updated visuals for a branch of the graph.
        /// </summary>
        void RequestBranchUpdate(NodeModel node);

        /// <summary>
        /// An IRenderPackageFactory object.
        /// </summary>
        IRenderPackageFactory RenderPackageFactory { get; }

        /// <summary>
        /// Create an IRenderPackage given an IGraphicItem
        /// </summary>
        IRenderPackage CreateRenderPackageFromGraphicItem(IGraphicItem graphicItem);

        /// <summary>
        /// An event triggered on the Selection of model.
        /// </summary>
        event Action<IEnumerable> SelectionHandled;

        /// <summary>
        /// An event triggered on the Deletion of model.
        /// </summary>
        event Action<NodeModel> DeletionHandled;

        /// <summary>
        /// An event triggered when a workspace is closed / open.
        /// </summary>
        event Action WorkspaceOpenedClosedHandled;

        /// Update all Node RenderPackages and raise notification.
        /// </summary>
        void UpdateAllNodeVisualsAndNotify();
    }
}
