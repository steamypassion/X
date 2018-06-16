﻿// WARNING: Please don't edit this file. It was generated by C++/WinRT v1.0.170906.1

#pragma once

#include "module.h"
#include "winrt/Windows.Foundation.h"
#include "winrt/Windows.Graphics.DirectX.h"
#include "winrt/Windows.Storage.h"
#include "winrt/Windows.UI.Composition.h"
#include "winrt/Microsoft.UI.Composition.Toolkit.h"

namespace winrt::Microsoft::UI::Composition::Toolkit::implementation {

template <typename D, typename ... I>
struct WINRT_EBO CompositionImage_base : impl::module_lock, implements<D, Microsoft::UI::Composition::Toolkit::ICompositionImage, I ...>
{
    using class_type = Microsoft::UI::Composition::Toolkit::CompositionImage;
    
    operator class_type() const noexcept
    {
        static_assert(std::is_same_v<typename D::first_interface, impl::default_interface_t<class_type>>);
        class_type result{ nullptr };
        attach_abi(result, detach_abi(static_cast<impl::default_interface_t<class_type>>(*this)));
        return result;
    }

    hstring GetRuntimeClassName() const
    {
        return L"Microsoft.UI.Composition.Toolkit.CompositionImage";
    }
};

}

#if defined(WINRT_FORCE_INCLUDE_COMPOSITIONIMAGE_XAML_G_H) || __has_include("CompositionImage.xaml.g.h")

#include "CompositionImage.xaml.g.h"

#else

namespace winrt::Microsoft::UI::Composition::Toolkit::implementation
{
    template <typename D, typename ... I>
    using CompositionImageT = CompositionImage_base<D, I ...>;
}

#endif