using java.util;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Windows;
using Buffer = SharpDX.Direct3D11.Buffer;
using Device = SharpDX.Direct3D11.Device;
using Vector3 = SharpDX.Vector3;
using Vector4 = SharpDX.Vector4;

namespace TestWithAP
{
    public class MoreDetails : RenderForm
    {
        private Device device;
        private SwapChain swapChain;
        private Texture2D backBuffer;
        private RenderTargetView renderTargetView;
        private Texture2D depthStencilBuffer;
        private DepthStencilView depthStencilView;
        private Viewport viewport;
        private DeviceContext deviceContext;

        private struct Vertex
        {
            public Vector3 Position;
            public Vector4 Color;
        }

        public MoreDetails()
        {
            // Set the window properties
            Text = "More Details";
            ClientSize = new System.Drawing.Size(800, 600);

            // Create the device and swap chain
            var description = new SwapChainDescription
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(ClientSize.Width, ClientSize.Height, new Rational(60, 1), Format.R8G8B8A8_UNorm),
                IsWindowed = true,
                OutputHandle = Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, description, out device, out swapChain);

            // Create the back buffer and render target view
            backBuffer = Texture2D.FromSwapChain<Texture2D>(swapChain, 0);
            renderTargetView = new RenderTargetView(device, backBuffer);

            // Create the depth stencil buffer and depth stencil view
            depthStencilBuffer = new Texture2D(device, new Texture2DDescription
            {
                ArraySize = 1,
                BindFlags = BindFlags.DepthStencil,
                Format = Format.D24_UNorm_S8_UInt,
                Width = ClientSize.Width,
                Height = ClientSize.Height,
                MipLevels = 1,
                SampleDescription = new SampleDescription(1, 0),
                Usage = ResourceUsage.Default
            });
            depthStencilView = new DepthStencilView(device, depthStencilBuffer);

            // Set the viewport
            viewport = new Viewport(0, 0, ClientSize.Width, ClientSize.Height, 0, 1);

            // Set the device context
            deviceContext = device.ImmediateContext;

            // Initialize the graphics
            InitializeGraphics();

            // Start the rendering loop
            RenderLoop.Run(this, Render);
        }

        private void InitializeGraphics()
        {
            // Define the input layout
            var inputElements = new[]
            {
                new InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0),
                new InputElement("COLOR", 0, Format.R32G32B32A32_Float, 12, 0)
            };
            var layout = new InputLayout(device, ShaderSignature.GetInputSignature(ShaderBytecode.CompileFromFile("VertexShader.hlsl", "VS", "vs_4_0")), inputElements);

            // Set the input layout
            deviceContext.InputAssembler.InputLayout = layout;

            // Compile and create the vertex shader
            var vertexShaderByteCode = ShaderBytecode.CompileFromFile("VertexShader.hlsl", "VS", "vs_4_0");
            var vertexShader = new
                        VertexShader(device, vertexShaderByteCode);

            // Set the vertex shader
            deviceContext.VertexShader.Set(vertexShader);

            // Compile and create the pixel shader
            var pixelShaderByteCode = ShaderBytecode.CompileFromFile("PixelShader.hlsl", "PS", "ps_4_0");
            var pixelShader = new PixelShader(device, pixelShaderByteCode);

            // Set the pixel shader
            deviceContext.PixelShader.Set(pixelShader);

            // Create the vertex buffer
            var vertices = new[]
            {
            new Vertex { Position = new Vector3(-0.5f, 0.5f, 0.0f), Color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f) },
            new Vertex { Position = new Vector3(0.5f, 0.5f, 0.0f), Color = new Vector4(0.0f, 1.0f, 0.0f, 1.0f) },
            new Vertex { Position = new Vector3(0.5f, -0.5f, 0.0f), Color = new Vector4(0.0f, 0.0f, 1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-0.5f, -0.5f, 0.0f), Color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f) }
        };
            var vertexBuffer = Buffer.Create(device, BindFlags.VertexBuffer, vertices);

            // Set the vertex buffer
            deviceContext.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertexBuffer, Utilities.SizeOf<Vertex>(), 0));

            // Create the index buffer
            var indices = new[] { 0, 1, 2, 0, 2, 3 };
            var indexBuffer = Buffer.Create(device, BindFlags.IndexBuffer, indices);

            // Set the index buffer
            deviceContext.InputAssembler.SetIndexBuffer(indexBuffer, Format.R32_UInt, 0);

            // Set the primitive topology
            deviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
        }

        private void Render()
        {
            // Clear the render target view and depth stencil view
            deviceContext.ClearRenderTargetView(renderTargetView, new Color4(0.0f, 0.0f, 0.0f, 1.0f));
            deviceContext.ClearDepthStencilView(depthStencilView, DepthStencilClearFlags.Depth, 1.0f, 0);

            // Set the render targets
            deviceContext.OutputMerger.SetTargets(depthStencilView, renderTargetView);

            // Set the viewport
            deviceContext.Rasterizer.SetViewport(viewport);

            // Draw the vertices
            deviceContext.DrawIndexed(6, 0, 0);

            // Present the back buffer
            swapChain.Present(0, PresentFlags.None);
        }
    }
}